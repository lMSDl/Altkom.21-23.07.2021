using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp.Delegates
{
    public class EventExample
    {
        public delegate void OddNumberDelegate();
        public event OddNumberDelegate OddNumberEvent;
        //OddNumberDelegate OddNumberEvent;

        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);
            if (result % 2 != 0)
                OddNumberEvent?.Invoke();
        }

        int _counter;
        void CountOddNumbers()
        {
            _counter++;
        }

        public void Test()
        {
            OddNumberEvent += CountOddNumbers;
            OddNumberEvent += delegate () { Console.WriteLine("*** Odd numer detected ***"); };

            for (var i = 0; i < 3; i++)
            {
                for (var ii = 0; ii < 3; ii++)
                {
                    Add(i, ii);
                }
            }

            Console.WriteLine($"Counter: {_counter}");
        }
    }
}
