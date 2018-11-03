namespace Moq.Tests.Code.Demo03
{
    public interface ICustomerAddressBuilder
    {
        Address From(CustomerToCreateDto customerToCreate);
    }
}