using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher : Person
    {
        public Teacher()
        {
        }

        public Teacher(string firstName, string lastName, DateTime birthDate, int id) : base(firstName, lastName, birthDate, id)
        {
        }

        public string Specialization { get; set; }
    }
}
