using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student : Person
    {
        public Student()
        {
        }

        public Student(string firstName, string lastName, DateTime birthDate, int index) : base(firstName, lastName, birthDate, index)
        {
        }

        public int Index { get => Id; set => Id = value; }
        public int YearOfStudy { get; set; }
        public float Grade { get; set; }

        public override string GetFullName()
        {
            return base.GetFullName() + " " + Index;
        }
    }
}
