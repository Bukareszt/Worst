using System;
namespace Backend.Package.Entities
{
    public class Handshake
    {
        public Guid Id { get; set; }
        public Guid GiverId { get; set; }
        public string AssociatedContacts { get; set; }
    }

}

