namespace Backend.Persistence.Entities
{
    public class HandshakeEntity
    {
        public Guid Id { get; set; }

        public UserEntity Giver { get; set; }

        public string AssociatedUsers { get; set; }
    }
}
