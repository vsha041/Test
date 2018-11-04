using System;
using Moq.Tests.Code.Demo11;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo11
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
                mockApplicationSettings.Setup(x => x.SystemConfiguration.AuditingInformation.WorkstationId).Returns(123);
                
                var customerService = new CustomerService(mockCustomerRepository.Object, mockApplicationSettings.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockApplicationSettings.VerifyGet(x => x.SystemConfiguration.AuditingInformation.WorkstationId);
            }

            [Test]
            public void the_workstation_id_if_no_value_throws_InvalidWorkstationIdException()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockApplicationSettings = new Mock<IApplicationSettings>();
                mockApplicationSettings.Setup(x => x.SystemConfiguration.AuditingInformation.WorkstationId).Returns((int?)null);

                var customerService = new CustomerService(mockCustomerRepository.Object, mockApplicationSettings.Object);

                //Act and Assert
                Assert.That(() => customerService.Create(new CustomerToCreateDto()), Throws.TypeOf<InvalidWorkstationIdException>());
            }
        }
    }
}