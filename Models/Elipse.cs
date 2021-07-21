using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Elipse : Shape2D
    {
        public override double Area
        {
            get
            {
                return Math.PI * Width / 2.0 * Height / 2.0;
            }
        }

        //public override double GetArea()
        //{
        //    return Math.PI * Width / 2.0 * Height / 2.0;
        //}
    }
}
