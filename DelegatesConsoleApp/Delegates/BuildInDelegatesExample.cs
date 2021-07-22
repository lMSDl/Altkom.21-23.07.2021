using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp.Delegates
{
    public class BuildInDelegatesExample
    {

        //public delegate void OddNumberDelegate();
        //public event OddNumberDelegate OddNumberEvent;
        public event EventHandler OddNumberEvent;

        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);
            if (result % 2 != 0)
                OddNumberEvent?.Invoke(this, EventArgs.Empty);
        }

        public bool Substract(int a, int b)
        {
            var result = a - b;
            Console.WriteLine(result);
            return result % 2 != 0;
        }

        int _counter;
        void CountOddNumbers()
        {
            _counter++;
        }

        public void Test()
        {
            //OddNumberEvent += CountOddNumbers;
            OddNumberEvent += BuildInDelegatesExample_OddNumberEvent;
            OddNumberEvent += delegate (object sender, EventArgs eventArgs) { Console.WriteLine("*** Odd numer detected ***"); };
            Method(Add, Substract);

            Console.WriteLine($"Counter: {_counter}");
        }

        private void BuildInDelegatesExample_OddNumberEvent(object sender, EventArgs e)
        {
            CountOddNumbers();
        }

        //delegate void Method1Delegate(int a, int b);
        //delegate bool Method2Delegate(int a, int b);
        //private void Method(Method1Delegate method1, Method2Delegate method2)
        private void Method(Action<int, int> method1, Func<int, int, bool> method2)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var ii = 0; ii < 3; ii++)
                {
                    method1(i, ii);
                    if (method2(i, ii))
                        OddNumberEvent.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
