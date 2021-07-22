using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICrudService<T>
    {
        void Create(T entity); 
        T Read(int id);
        IEnumerable<T> Read();
        bool Update(int id, T entity);
        bool Delete(int id);
    }
}
