using Microsoft.EntityFrameworkCore;
using Backend.Persistence.Entities;
using Backend.Package.Entities;

namespace Backend.Persistence
{
    public class HandshakeRepository : IHandshakeRepository
    {
        private readonly BackendDbContext context;

        public HandshakeRepository(BackendDbContext context)
        {
            this.context = context;
        }

        public void CreateHandshake(Handshake handshake)
        {

            var giver = context.Users.SingleOrDefault(u => u.Id == handshake.GiverId);

            context.Handshakes.Add(new HandshakeEntity
            {
                Giver = giver,
                Id = handshake.Id,
                AssociatedUsers = handshake.AssociatedContacts
            });

            context.SaveChanges();
        }

        public void AcceptHandshake(Guid userId, Handshake handshake)
        {

            throw new NotImplementedException();
        }
    }

}
