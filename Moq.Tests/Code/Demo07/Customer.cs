namespace Moq.Tests.Code.Demo07
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerStatus StatusLevel { get; set; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}