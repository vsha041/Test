using Moq.Tests.Code.Demo07;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo07
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_platinum_status_customer
        {
            [Test]
            public void a_special_save_routine_should_be_used()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockCustomerStatusFactory = new Mock<ICustomerStatusFactory>();

                var customerToCreate = new CustomerToCreateDto
                                           {
                                               DesiredStatus = CustomerStatus.Platinum, 
                                               FirstName = "Bob", 
                                               LastName = "Builder"
                                           };

                // when the createFrom method is called, it's parameter's DesiredStatus property will be 
                // CustomerStatus.Platinum and the function itself will return CustomerStatus.Platinum
                // this way it will execute the appropriate branching logic.
                mockCustomerStatusFactory
                    .Setup(x => x.CreateFrom(It.Is<CustomerToCreateDto>(y => y.DesiredStatus == CustomerStatus.Platinum)))
                    .Returns(CustomerStatus.Platinum);

                var customerService = new CustomerService(mockCustomerRepository.Object, mockCustomerStatusFactory.Object);

                //Act
                customerService.Create(customerToCreate);

                //Assert
                mockCustomerRepository.Verify(x=>x.SaveSpecial(It.IsAny<Customer>()));
            }
        }
    }
}