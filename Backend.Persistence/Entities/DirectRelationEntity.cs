using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Persistence.Entities
{
    public class DirectContactEntity
    {
        public Guid Id { get; set; }

        public Guid GiverId { get; set; }

        [ForeignKey("GiverId")]
        public UserEntity Giver { get; set; }

        public Guid ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public UserEntity Receiver { get; set; }

        //public IEnumerable<IndirectRelationEntity> AssociatedContacts { get; set; }
    }
}
