namespace Backend.Package.Entities
{
    public class DirectContact
    {
        public User ContactProfile { get; set; }
        public IEnumerable<User> AssociatedContacts { get; set; }
    }
}
