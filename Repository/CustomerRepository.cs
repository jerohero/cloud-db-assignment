using BMH.DAL;
using BMH.Domain;
using BMH.Repository.Interfaces;

namespace BMH.Repository
{
    public class CustomerRepository : IBaseRepository<Customer>, ICustomerRepository
    {
        private BMHContext Context { get; }

        public CustomerRepository(BMHContext context)
        {
            Context = context;
        }

        public Customer Add(Customer entity)
        {
            Context.Customers.Add(entity);
            Commit();
            return entity;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public int Count()
        {
            return Context.Customers.Count();
        }

        public void Delete(Customer entity)
        {
            Context.Remove(entity);
            Commit();
        }

        public IEnumerable<Customer> FindBy(Func<Customer, bool> predicate)
        {
            return Context.Customers.Where(predicate);
        }

        public IEnumerable<Customer> GetAll()
        {
            return Context.Customers;
        }

        public Customer GetSingle(int id)
        {
            return Context.Customers.Where(u => u.Id == id)
                .FirstOrDefault();
        }

        public Customer Update(Customer entity)
        {
            Context.Customers.Update(entity);
            Commit();
            return entity;
        }
    }
}