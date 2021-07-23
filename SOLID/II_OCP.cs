using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.O
{
    abstract class Shape
    {
        public abstract double GetArea();
    }

    class Square : Shape
    {
        public int A { get; set; }

        public override double GetArea()
        {
            return A * A;
        }
    }

    class Rectangle : Shape
    {
        public int A { get; set; }
        public int B { get; set; }
        public override double GetArea()
        {
            return A * B;
        }
    }

    class Circle : Shape {
        public int R {get; set; }
        public override double GetArea()
        {
            return R*R*Math.PI;
        }
    }

    class ShapeCalculator
    {
        double Area(Shape shape)
        {
            return shape.GetArea();
            //switch (shape)
            //{
            //    case Square square:
            //        return square.A * square.A;
            //    case Rectangle rectangle:
            //        return rectangle.A * rectangle.B;
            //    case Circle circle:
            //        return circle.R * circle.R * Math.PI;
            //    default:
            //        return 0;
            //}
        }
    }
}
