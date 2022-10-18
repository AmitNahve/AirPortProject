using System.Collections.Generic;
namespace Contract
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Delete(T entity);
        void Create(T entity);
        void Update(T entity);
    }
}
