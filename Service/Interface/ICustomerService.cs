using BMH.Domain;
using BMH.Domain.Models;

namespace BMH.Service
{
    public interface ICustomerService
    {
        public Customer CreateCustomer(Customer customer);
    }
}