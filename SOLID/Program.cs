using SOLID.L2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 5;
            var b = 3;

            Rectangle rectangle = new Square();
            FillRectangle(rectangle, a, b);
            ShowArea(rectangle);

            Console.ReadLine();
        }

        static void FillRectangle(Rectangle rectangle, int a, int b)
        {
            Console.WriteLine($"a = {a}; b = {b}");
            rectangle.A = a;
            rectangle.B = b;
        }

       static void ShowArea(Rectangle rectangle)
        {
            Console.WriteLine(rectangle.GetArea());
        }
    }
}
