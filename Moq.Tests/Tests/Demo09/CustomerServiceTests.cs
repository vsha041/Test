using Moq.Tests.Code.Demo09;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo09
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void the_local_timezone_should_be_set()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();

                var customerService = new CustomerService(mockCustomerRepository.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockCustomerRepository.VerifySet(x => x.LocalTimeZone = It.IsAny<string>());
            }
        }
    }
}