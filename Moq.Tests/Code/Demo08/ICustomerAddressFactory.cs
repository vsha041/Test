namespace Moq.Tests.Code.Demo08
{
    public interface ICustomerAddressFactory
    {
        Address From(CustomerToCreateDto customerToCreate);
    }
}