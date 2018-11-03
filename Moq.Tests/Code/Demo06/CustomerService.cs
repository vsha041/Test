namespace Moq.Tests.Code.Demo06
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFullNameBuilder _customerFullName;

        public CustomerService(
            ICustomerRepository customerRepository, 
            ICustomerFullNameBuilder customerFullName)
        {
            _customerRepository = customerRepository;
            _customerFullName = customerFullName;
        }

        public void Create(CustomerToCreateDto customerToCreateDto)
        {
            string fullName = _customerFullName.From(customerToCreateDto.FirstName, customerToCreateDto.LastName);
            Customer customer = new Customer(fullName);
            _customerRepository.Save(customer);
        }
    }
}