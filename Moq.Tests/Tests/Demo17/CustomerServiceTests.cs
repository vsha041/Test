using Moq.Tests.Code.Demo17;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo17
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_new_customer
        {
            [Test]
            public void the_address_should_be_formatted()
            {
                //Arrange
                var mockFactory = new MockRepository(MockBehavior.Loose)
                {
                    DefaultValue = DefaultValue.Mock
                };

                var mockCustomerRepository = mockFactory.Create<ICustomerRepository>();
                var mockCustomerAddressFormatter = mockFactory.Create<ICustomerAddressFormatter>();

                mockCustomerAddressFormatter.Setup(x => x.For(It.IsAny<CustomerToCreateDto>())).Returns(new Address());

                var customerService = new CustomerService(mockCustomerRepository.Object, mockCustomerAddressFormatter.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockFactory.Verify();
            }
        }
    }
}
