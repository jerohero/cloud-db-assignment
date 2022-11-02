using Domain.Entity;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository CustomerRepository { get; }

        public CustomerService(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            return CustomerRepository.Add(customer);
        }
    }
}