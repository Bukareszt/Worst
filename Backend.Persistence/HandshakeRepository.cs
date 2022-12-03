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

        public Handshake GetHandshake(Guid id)
        {
            var handshake = context.Handshakes.Include(c => c.Giver).SingleOrDefault(h => h.Id == id);
            if (handshake is null) { throw new InvalidOperationException($"Handshake {id} doesn't exist!"); }
            return new Handshake
            {
                Id = handshake.Id,
                GiverId = handshake.Giver.Id,
                AssociatedContacts = handshake.AssociatedUsers
            };
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
    }
}
