using Backend.Package.Entities;

namespace Backend.Persistence
{
    public interface IHandshakeRepository
    {
        void CreateHandshake(Handshake handshake);
        void AcceptHandshake(Guid userId, Handshake handshake);
    }
}
