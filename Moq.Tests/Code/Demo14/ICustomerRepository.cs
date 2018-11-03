using System.Collections.Generic;

namespace Moq.Tests.Code.Demo14
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        IEnumerable<Customer> FetchAll();
    }
}