using Moq.Tests.Code.Demo18;
using NUnit.Framework;

namespace Moq.Tests.Tests.Demo18
{
    public class CustomerNameFormatterTests
    {
        [TestFixture]
        public class When_formatting_a_customers_name
        {
            [Test]
            public void all_bad_words_should_be_scrubbed()
            {
                //Arrange
                var mockCustomerNameFormatter = new Mock<CustomerNameFormatter>();



                //Act
                mockCustomerNameFormatter.Object.From(new Customer());

                //Assert
                mockCustomerNameFormatter.Verify();
            }
        }
    }
}