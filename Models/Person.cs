using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Person : Entity
    {
        protected Person()
        {
        }

        protected Person(string firstName, string lastName, DateTime birthDate, int id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
