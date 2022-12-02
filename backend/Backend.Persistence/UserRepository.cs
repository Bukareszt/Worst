using Microsoft.EntityFrameworkCore;
using Backend.Persistence.Entities;
using Backend.Package.Entities;

namespace Backend.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext context;

        public UserRepository(UserDbContext context)
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
                Username = user.Username,
                PasswordHash = user.PasswordHash
            };
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User>? users = null;

            users = context.Users.Select(u => new User
            {
                Username = u.Username
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
                PasswordHash = user.PasswordHash
            });

            context.SaveChanges();
        }

        /*public IEnumerable<Contact> GetImmediateContacts(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetAllContacts(Guid id)
        {
            throw new NotImplementedException();
        }*/
    }
}
