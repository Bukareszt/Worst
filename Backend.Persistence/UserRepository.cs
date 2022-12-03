using Microsoft.EntityFrameworkCore;
using Backend.Persistence.Entities;
using Backend.Package.Entities;

namespace Backend.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly BackendDbContext context;

        public UserRepository(BackendDbContext context)
        {
            this.context = context;
        }

        public void Migrate()
        {
            context.Database.Migrate();
        }

        public User GetUser(Guid id)
        {
            UserEntity? user = context.Users.SingleOrDefault(c => c.Id == id);
            if (user is null)
            {
                throw new ArgumentException($"User with id: {id} does not exist");
            }
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                PasswordHash = user.PasswordHash
            };
        }

        public User GetUser(string username)
        {
            UserEntity? user = context.Users.SingleOrDefault(c => c.Username == username);

            if (user is null)
            {
                throw new ArgumentException($"User with username: {username} does not exist");
            }

            return new User
            {
                Id = user.Id,
                Username = user.Username,
                PasswordHash = user.PasswordHash
            };
        }

        public User GetProfile(string username)
        {
            UserEntity? user = context.Users.SingleOrDefault(c => c.Username == username);

            IEnumerable<User> contacts = context.DirectRelations
              .Where(dc => dc.GiverId == user.Id || dc.ReceiverId == user.Id)
              .Select(dc => dc.ReceiverId == user.Id ? dc.Giver : dc.Receiver)
              .Select(user => new User
              {
                  Id = user.Id,
                  Username = user.Username,
                  Name = user.Name,
                  Surname = user.Surname,
                  Email = user.Email,
                  PhoneNumber = user.PhoneNumber
              });

            foreach (var contact in contacts)
            {
                //contact.Contacts = context.IndirectRelations
            }

            if (user is null)
            {
                throw new ArgumentException($"User with username: {username} does not exist");
            }

            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Contacts = contacts
            };
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = context.Users.Select(u => new User
            {
                Username = u.Username,
                Email = u.Email,
                Name = u.Name,
                Surname = u.Surname
            });

            return users!;
        }

        public bool UserExists(string username)
        {
            bool exists = context.Users.Any(c => c.Username == username);
            return exists;
        }

        public void SaveUser(User user)
        {
            context.Users.Add(new UserEntity
            {
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            });

            context.SaveChanges();
        }

        public void AddContact(string receiverId, Guid giverId)
        {
            var receiver = context.Users.SingleOrDefault(u => u.Username == receiverId);

            var giver = context.Users.SingleOrDefault(u => u.Id == giverId);

            context.DirectRelations.Add(new DirectContactEntity
            {
                GiverId = giver.Id,
                ReceiverId = receiver.Id,
                Id = Guid.NewGuid()
            });

            context.SaveChanges();
        }

        public void AddIndirectContact(string receiverId, Guid giverid, IEnumerable<string> contacts)
        {

        }


        public IEnumerable<DirectContact> GetContacts(Guid id)
        {
            throw new NotImplementedException();
            /*return context.DirectRelations
              .Where(rel => rel.Receiver.Id == id)
              .Include(dc => dc.AssociatedContacts)
              .Select(dc => new DirectContact
              {
                  ContactProfile = new User
                  {
                      Username = dc.Giver.Username,

                  }
              });*/
        }

    }
}
