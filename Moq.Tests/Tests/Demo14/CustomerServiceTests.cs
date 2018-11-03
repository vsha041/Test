using Moq.Tests.Code.Demo14;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo14
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void the_customer_should_be_saved()
            {
                //Arrange
                var mockCustomerRepository = 
                    new Mock<ICustomerRepository>();

                mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));

                var customerService = new CustomerService(
                    mockCustomerRepository.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockCustomerRepository.Verify();
            }
        }
    }
}