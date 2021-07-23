using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt32(this string @string)
        {
            return int.Parse(@string);
        }
        public static float ToFloat(this string @string)
        {
            return float.Parse(@string);
        }
        public static DateTime ToDateTime(this string @string)
        {
            return DateTime.Parse(@string);
        }
        public static Commands? ToCommand(this string @string)
        {
            if (Enum.TryParse<Commands>(@string, true, out var command))
                return command;
            return null;
        }
    }
}
