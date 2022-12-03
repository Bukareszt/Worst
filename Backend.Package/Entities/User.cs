using System;

namespace Backend.Package.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public IEnumerable<User> Contacts { get; set; }
    }
}
