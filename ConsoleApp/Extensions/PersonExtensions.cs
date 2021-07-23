using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp.Extensions
{
    public static class PersonExtensions
    {
        public static void Export(this Person person, string path)
        {
            var json  = JsonConvert.SerializeObject(person, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static T Import<T>(this string path)
        {
            var json = File.ReadAllText(path);
            var person = JsonConvert.DeserializeObject<T>(json);
            
            return person;
        }
    }
}
