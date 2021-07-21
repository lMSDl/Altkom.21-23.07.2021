using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //var shape = new Shape();
            Shape2D shape1 = new Elipse();

            shape1.Width = 5;
            shape1.Height = 10;

            var area = shape1.Area;

            Console.WriteLine(area);


            Shape shape2 = new Line("linia");
            //shape2.Name
            shape2.SomeMethod();

            Console.ReadLine();
        }
    }
}
