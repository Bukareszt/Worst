namespace Backend.Persistence.Entities
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public UserEntity Owner { get; set; }
        public UserEntity Receiver { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
