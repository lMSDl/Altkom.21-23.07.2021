using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rectangle : Shape2D
    {
        public override double Area => Height * Width;

        //public override double GetArea()
        //{
        //    return Height * Width;
        //}
    }
}
