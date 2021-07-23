using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.L2
{
    abstract class Shape
    {
        public abstract double GetArea();
    }

    class Square : Rectangle
    {
        public override int A { get => base.A; set => base.A = base.B = value; }
        public override int B { get => base.B; set => base.B = base.A = value; }

    }

    class Rectangle : Shape
    {
        public virtual int A { get; set; }
        public virtual int B { get; set; }
        public override double GetArea()
        {
            return A * B;
        }
    }
}
