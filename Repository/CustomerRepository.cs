using DAL;
using Domain.Entity;
using Repository.Interface;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private BmhContext Context { get; }

        public CustomerRepository(BmhContext context)
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
            return Context.Customers.FirstOrDefault(u => u.Id == id);
        }

        public Customer Update(Customer entity)
        {
            Context.Customers.Update(entity);
            Commit();
            return entity;
        }
    }
}