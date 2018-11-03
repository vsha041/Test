using System;

namespace Moq.Tests.Code.Demo08
{
    public class CustomerCreationException : Exception
    {
        public CustomerCreationException(Exception exception):base("error",exception)
        {
            
        }
    }
}