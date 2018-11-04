using Moq.Tests.Code.Demo16;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo16
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void the_address_should_be_formatted()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();

                // Mock object returning a Mock object
                var mockAddressFormatterFactory = new Mock<IAddressFormatterFactory>
                {
                    DefaultValue = DefaultValue.Mock
                };

                IAddressFormatter addressFormatter = mockAddressFormatterFactory.Object.From(It.IsAny<string>());
                Mock<IAddressFormatter> mock = Mock.Get(addressFormatter);

                //Act
                var customerService = new CustomerService(mockCustomerRepository.Object, mockAddressFormatterFactory.Object);
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mock.Verify(x => x.From(It.IsAny<CustomerToCreateDto>()));
            }
        }
    }
}