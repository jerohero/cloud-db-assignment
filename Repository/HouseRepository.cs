using BMH.DAL;
using BMH.Repository.Interfaces;
using Repository;

namespace BMH.Repository
{
    public class HouseRepository : IBaseRepository<House>, IHouseRepository
    {
        private BMHContext Context { get; }

        public HouseRepository(BMHContext context)
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
            return Context.Houses.Where(u => u.Id == id)
                .FirstOrDefault();
        }

        public House Update(House entity)
        {
            Context.Houses.Update(entity);
            Commit();
            return entity;
        }
    }
}