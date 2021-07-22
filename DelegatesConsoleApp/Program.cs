using DelegatesConsoleApp.Delegates;
using DelegatesConsoleApp.LambdaExpressions;
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

            //new BuildInDelegatesExample().Test();

            //new LambdaExpressionsExample().Test();

            new LinqExamples().Test();

            Console.ReadLine();
        }
    }
}
