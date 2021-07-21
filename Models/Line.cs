using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Line : Shape1D
    {
        public Line(string name) : base(name)
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public override void SomeMethod()
        {
            Console.WriteLine("Hello from " + Name);
        }
    }
}
