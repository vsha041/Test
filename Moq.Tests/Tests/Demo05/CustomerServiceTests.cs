﻿using System.Collections.Generic;
using Moq.Tests.Code.Demo05;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo05
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void each_customer_should_be_assigned_an_id()
            {
                //Arrange
                var listOfCustomersToCreate = new List<CustomerToCreateDto>
                                                  {
                                                      new CustomerToCreateDto(),
                                                      new CustomerToCreateDto()
                                                  };

                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockIdFactory = new Mock<IIdFactory>();

                var i = 1;
                mockIdFactory.Setup(x => x.Create()).Returns(() => i).Callback(() => i++);

                var customerService = new CustomerService(mockCustomerRepository.Object, mockIdFactory.Object);

                //Act
                customerService.Create(listOfCustomersToCreate);

                //Assert
                mockIdFactory.Verify(x => x.Create(), Times.AtLeastOnce());
            }
        }
    }
}