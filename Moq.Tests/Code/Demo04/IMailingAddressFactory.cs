namespace Moq.Tests.Code.Demo04
{
    public interface IMailingAddressFactory
    {
        bool TryParse(string address, out MailingAddress mailingAddress);
    }
}