using Models;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class CrudService<T> : ICrudService<T>, ICrudAsyncService<T> where T : Entity
    {
        protected ICollection<T> _entities = new List<T>();

        public void Create(T entity)
        {
            _entities.Add(entity);
        }

        public Task CreateAsync(T entity)
        {
            return Task.Run(() => Create(entity));
        }

        public bool Delete(int id)
        {
            var entity = Read(id);
            if (entity == null)
                return false;
            return _entities.Remove(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return Task.Run(() => Delete(id));
        }

        public T Read(int id)
        {
            //Enumerable.SingleOrDefault(_entities, x => x.Id == id);
            return _entities.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> Read()
        {
            Thread.Sleep(5000);

            return _entities.ToList();
        }

        public Task<T> ReadAsync(int id)
        {
            return Task.Run(() => Read(id));
        }

        public Task<IEnumerable<T>> ReadAsync()
        {
            return Task.Run(() => Read());
        }

        public bool Update(int id, T entity)
        {
            if (!Delete(id))
                return false;
            entity.Id = id;
            Create(entity);
            return true;
        }

        public Task<bool> UpdateAsync(int id, T entity)
        {
            return Task.Run(() => Update(id, entity));
        }
    }
}
