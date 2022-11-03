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
            if (!CustomerRepository.IsEmailUnique(customer.Email))
                throw new Exception("A customer with this email address already exists.");

            return CustomerRepository.Add(customer);
        }

        public List<Customer> GetAll()
        {
            return CustomerRepository.GetAll().ToList();
        }
    }
}