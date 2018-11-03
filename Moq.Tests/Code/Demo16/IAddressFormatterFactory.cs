namespace Moq.Tests.Code.Demo16
{
    public interface IAddressFormatterFactory
    {
        IAddressFormatter From(string country);
    }
}