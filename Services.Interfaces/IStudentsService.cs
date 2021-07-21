using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStudentsService
    {
        void Create(Student student); 
        Student Read(int index);
        IEnumerable<Student> Read();
        bool Update(int index, Student student);
        bool Delete(int index);
    }
}
