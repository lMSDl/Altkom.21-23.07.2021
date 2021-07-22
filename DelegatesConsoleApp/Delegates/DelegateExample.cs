using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp.Delegates
{
    public class DelegateExample
    {
        delegate void NoParametersNoReturnDelegate();
        delegate void NoReturnDelegate(string value);
        delegate bool Delegate(int a, int b);


        public void Func1()
        {
            Console.WriteLine("1");
        }
        public void Func2(string @string)
        {
            Console.WriteLine(@string);
        }
        public bool Func3(int a, int b)
        {
            Console.WriteLine($"3: {a} {b}");
            return a == b;
        }

        Delegate Delegate3 { get; set; }

        public void Test()
        {
            var delegate1 = new NoParametersNoReturnDelegate(Func1);
            delegate1();

            NoReturnDelegate delegate2 = null;
            //if(delegate2 != null)
            //    delegate2("2");
            
            delegate2?.Invoke("2");
            delegate2 = Func2;
            delegate2?.Invoke("2");

            Delegate3 = Func3;

            for (var i = 0; i < 3; i++)
            {
                for (var ii = 0; ii < 3; ii++)
                {
                    if (Delegate3(i, ii))
                        //if (Delegate3.Invoke(i, ii))
                            Console.WriteLine("==");
                }
            }
        }
    }
}
