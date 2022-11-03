using Domain.Entity;

namespace Repository.Interface
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public bool IsEmailUnique(string email);
    }
}