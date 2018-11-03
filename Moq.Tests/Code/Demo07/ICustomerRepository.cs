namespace Moq.Tests.Code.Demo07
{
    public interface ICustomerRepository
    {
        void SaveSpecial(Customer customer);
        void Save(Customer customer);
    }
}