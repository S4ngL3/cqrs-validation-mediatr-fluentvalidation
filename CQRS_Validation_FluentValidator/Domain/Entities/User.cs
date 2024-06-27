namespace Contracts.Entities
{
    public sealed class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void Update(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);
    }
}
