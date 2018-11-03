﻿using Moq.Tests.Code.Demo04;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo04
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void the_customer_should_be_persisted()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockMailingAddressFactory = new Mock<IMailingAddressFactory>();


                var customerService = new CustomerService(
                    mockCustomerRepository.Object, mockMailingAddressFactory.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockCustomerRepository.Verify(x=>x.Save(It.IsAny<Customer>()));
            }
        }
    }
}