using BMH.Domain;
using BMH.Repository.Interfaces;

namespace BMH.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository { get; }

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepository.Add(customer);
        }
    }
}