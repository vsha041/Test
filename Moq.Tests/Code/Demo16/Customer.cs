namespace Moq.Tests.Code.Demo16
{
    public class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Customer(string name)
        {
            Name = name;
        }
    }
}