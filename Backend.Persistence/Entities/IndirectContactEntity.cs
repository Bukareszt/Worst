namespace Backend.Persistence.Entities
{
    public class IndirectRelationEntity
    {
        public Guid ContactId { get; set; }

        public Guid UserId { get; set; }
    }
}
