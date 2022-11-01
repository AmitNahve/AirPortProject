using System.Collections.Generic;
namespace Shared.ContextRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        T Get(int id);
        void Delete(T entity);
        void Create(T entity);
        void Update(T entity);
    }
}
