using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        readonly AirPortContext context;
        public BaseRepository(AirPortContext context) => this.context = context;
        public void Create(T entity) => context.Set<T>().Add(entity);

        public void Delete(T entity) => context.Set<T>().Remove(entity);

        public T Get(int id) => context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => context.Set<T>().ToList();

        public void Update(T entity) => context.Set<T>().Update(entity);

    }
}
