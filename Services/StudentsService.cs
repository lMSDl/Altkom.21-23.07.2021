using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class StudentsService : CrudService<Student>, IStudentsService
    {
        ////private ICollection<Student> _students;
        //private IList<Student> _students;

        public StudentsService()
        {
            Create(new Student("Ewa", "Ewowska", new DateTime(1990, 12, 23), 123987));
            Create(new Student("Michał", "Michałowski", new DateTime(1995, 1, 3), 523768));
        }

        //public void Create(Student student)
        //{
        //    _students.Add(student);
        //}

        //public bool Delete(int index)
        //{
        //    var student = Read(index);
        //    if (student == null)
        //        return false;
        //    return _students.Remove(student);
        //}

        //public Student Read(int index)
        //{
        //    //for (var i = 0; i < _students.Count; i++ /*i += 1*/ /*i = i + 1*/)
        //    //{
        //    //    var student = _students[i];
        //    //foreach (var student in _students)
        //    //{
        //    //    if (student.Index == index)
        //    //        return student;
        //    //}

        //    //int i = 0;
        //    //while(i < _students.Count)
        //    //{
        //    //    var student = _students[i++];
        //    //    if (student.Index == index)
        //    //        return student;
        //    //}

        //    //return null;

        //    return _students.SingleOrDefault(x => x.Index == index);
        //}

        //public IEnumerable<Student> Read()
        //{
        //    return _students;
        //}

        //public bool Update(int index, Student student)
        //{
        //    if (!Delete(index))
        //        return false;
        //    student.Index = index;
        //    Create(student);
        //    return true;
        //}
    }
}
