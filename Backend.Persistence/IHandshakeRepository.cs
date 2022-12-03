using Backend.Package.Entities;

namespace Backend.Persistence
{
    public interface IHandshakeRepository
    {
        Handshake GetHandshake(Guid id);
        void CreateHandshake(Handshake handshake);
        void DeleteHandshake(Guid id);
    }
}
