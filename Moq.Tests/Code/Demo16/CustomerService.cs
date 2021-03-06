﻿namespace Moq.Tests.Code.Demo16
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressFormatterFactory _addressFormatterFactory;

        public CustomerService(ICustomerRepository customerRepository, IAddressFormatterFactory addressFormatterFactory)
        {
            _customerRepository = customerRepository;
            _addressFormatterFactory = addressFormatterFactory;
        }

        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(customerToCreate.Name);

            var addressFormatter = _addressFormatterFactory.From(customerToCreate.Country);

            // we want to verify that the From method of IAddressFormatterFactory is actually executed
            customer.Address = addressFormatter.From(customerToCreate);

            _customerRepository.Save(customer);
        }
    }
}