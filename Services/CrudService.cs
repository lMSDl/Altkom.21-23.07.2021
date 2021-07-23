using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CrudService<T> : ICrudService<T> where T : Entity
    {
        protected ICollection<T> _entities = new List<T>();

        public void Create(T entity)
        {
            _entities.Add(entity);
        }

        public bool Delete(int id)
        {
            var entity = Read(id);
            if (entity == null)
                return false;
            return _entities.Remove(entity);
        }

        public T Read(int id)
        {
            //Enumerable.SingleOrDefault(_entities, x => x.Id == id);
            return _entities.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> Read()
        {
            return _entities.ToList();
        }

        public bool Update(int id, T entity)
        {
            if (!Delete(id))
                return false;
            entity.Id = id;
            Create(entity);
            return true;
        }
    }
}
