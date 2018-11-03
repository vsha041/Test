using Moq.Tests.Code.Demo12;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo12
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void the_workstation_id_should_be_retrieved()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockApplicationSettings = new Mock<IApplicationSettings>();


                var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockApplicationSettings.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockApplicationSettings.VerifyGet(x=>x.WorkstationId);
            }
        }
    }
}