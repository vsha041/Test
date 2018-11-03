﻿using System.Collections.Generic;
using Moq.Code.Demo02;
using NUnit.Framework;

namespace Moq.Tests.Demo02
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_multiple_customers
        {
            //shows how to verify that a method was called an explicit number of times
            [Test]
            public void the_customer_repository_should_be_called_once_per_customer()
            {
                //Arrange
                var listOfCustomerDtos = new List<CustomerToCreateDto>
                    {
                        new CustomerToCreateDto
                            {
                                FirstName = "Sam", LastName = "Sampson"
                            },
                        new CustomerToCreateDto
                            {
                                FirstName = "Bob", LastName = "Builder"
                            },
                        new CustomerToCreateDto
                            {
                                FirstName = "Doug", LastName = "Digger"
                            }
                    };

                //Act

                //Assert

            }
        }
    }
}