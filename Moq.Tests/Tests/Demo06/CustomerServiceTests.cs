using System;
using System.Linq.Expressions;
using Moq.Tests.Code.Demo06;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo06
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            //verify that specific parameter values are passed to the mock object
            [Test]
            public void a_full_name_should_be_created_from_first_and_last_name()
            {
                //Arrange
                var customerToCreateDto = new CustomerToCreateDto
                {
                    FirstName = "Bob",
                    LastName = "Builder"
                };

                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockFullNameBuilder = new Mock<ICustomerFullNameBuilder>();

                mockFullNameBuilder.Setup(x => x.From(It.IsAny<string>(), It.IsAny<string>()));

                var customerService = new CustomerService(mockCustomerRepository.Object, mockFullNameBuilder.Object);

                //Act
                customerService.Create(customerToCreateDto);

                //Assert
                Expression<Func<string, bool>> firstName = fn => fn.Equals(customerToCreateDto.FirstName, StringComparison.InvariantCultureIgnoreCase);
                Expression<Func<string, bool>> lastName = fn => fn.Equals(customerToCreateDto.LastName, StringComparison.InvariantCultureIgnoreCase);

                // Verify that the From function's first parameter is Bob and second parameter is Builder
                mockFullNameBuilder.Verify(x => x.From(It.Is(firstName), It.Is(lastName)));
            }
        }
    }
}