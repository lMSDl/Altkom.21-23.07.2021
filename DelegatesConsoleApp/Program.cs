using DelegatesConsoleApp.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //new DelegateExample().Test();
            //new MulticastDelegateExample().Test();
            //var eventExample = new EventExample();

            //eventExample.OddNumberEvent += delegate () { Console.WriteLine( "External delegate"); };

            ////eventExample.OddNumberEvent = null;

            //eventExample.Test();

            new BuildInDelegatesExample().Test();

            Console.ReadLine();
        }
    }
}
