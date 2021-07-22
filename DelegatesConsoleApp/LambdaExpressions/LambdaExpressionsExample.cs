using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp.LambdaExpressions
{
    public class LambdaExpressionsExample
    {
        Func<int, int, int> Calculator { get; set; }
        Action<string> SomeAction { get; set; }
        Action AnotherAction { get; set; }

        public void Test()
        {
            Calculator += //delegate (int a, int b) { return a + b; };
                          //(a, b) => { return a + b; };
                            (a, b) => a + b;

            SomeAction += //(param) => Console.WriteLine(param);
                            param => Console.WriteLine(param);

            AnotherAction += () => Console.WriteLine("Hello!");

            SomeMethod(x =>
           {
               var value = x.Replace(',', '?');
               Console.WriteLine(value);
           }, "ABC, BCD, CDE");
        }

        void SomeMethod(Action<string> stringAction, string patameter)
        {
            stringAction.Invoke(patameter);
        }

    }
}
