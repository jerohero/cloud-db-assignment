using Repository.Interface;

namespace BMH.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        IEnumerable<T> GetAll();
        int Count();
        T GetSingle(int id);
        IEnumerable<T> FindBy(Func<T, bool> predicate);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Commit();
    }
}