using Domain.Entity;

namespace Service.Interface
{
    public interface ICustomerService
    {
        public Customer CreateCustomer(Customer customer);
    }
}