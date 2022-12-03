using System;

namespace Backend.Persistence.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; } = "";

        public string Surname { get; set; } = "";

        public string Email { get; set; } = "";

        public IEnumerable<DirectRelationEntity> DirectContacts { get; set; }
    }
}
