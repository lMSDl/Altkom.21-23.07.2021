using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Shape2D : Shape1D
    {
        public int Height {get; set;}

        //public abstract double GetArea();

        public abstract double Area { get; }
    }
}
