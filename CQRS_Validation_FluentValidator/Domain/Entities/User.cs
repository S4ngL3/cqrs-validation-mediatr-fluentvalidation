namespace Contracts.Entities
{
    public sealed class User
    {
        public User(string firstName, string lastName)
             : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private User()
        {
        }

        public int Id { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void Update(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);
    }
}
