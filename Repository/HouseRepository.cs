using DAL;
using Domain.Entity;
using Repository.Interface;

namespace Repository
{
    public class HouseRepository : IHouseRepository
    {
        private BmhContext Context { get; }

        public HouseRepository(BmhContext context)
        {
            Context = context;
        }

        public House Add(House entity)
        {
            Context.Houses.Add(entity);
            Commit();
            return entity;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public int Count()
        {
            return Context.Houses.Count();
        }

        public void Delete(House entity)
        {
            Context.Remove(entity);
            Commit();
        }

        public IEnumerable<House> FindBy(Func<House, bool> predicate)
        {
            return Context.Houses.Where(predicate);
        }

        public IEnumerable<House> GetAll()
        {
            return Context.Houses;
        }

        public House GetSingle(int id)
        {
            return Context.Houses.FirstOrDefault(u => u.Id == id);
        }

        public House Update(House entity)
        {
            Context.Houses.Update(entity);
            Commit();
            return entity;
        }
    }
}