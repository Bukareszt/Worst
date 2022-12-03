namespace Backend.Persistence.Entities
{
    public class DirectRelationEntity
    {
        public Guid Id { get; set; }
        public UserEntity Giver { get; set; }
        public UserEntity Receiver { get; set; }
    }
}
