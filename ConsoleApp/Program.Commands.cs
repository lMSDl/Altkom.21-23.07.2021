using ConsoleApp.Models;
using Models;
using Services;
using Services.Interfaces;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ConsoleApp
{
    static partial class Program
    {
        private static void Create()
        {
            var student = new Student();
            Edit(student);
            Service.Create(student);
        }

        private static void Update()
        {
            var index = GetStudentIndex();
            if(index.HasValue)
            {
                var student = Service.Read(index.Value);
                Edit(student);

                Service.Update(index.Value, student);
            }
        }

        private static void Edit(Student student)
        {
            Func<string, int> converter = input => {
                var index = int.Parse(input);
                if(index < 100000 || index > 999999)
                    throw new FormatException("Niepoprawna ilość znaków");
                return index; 
            };
            student.Index = EditProperty(Properties.Resources.Index, student.Index, converter);

            student.FirstName = EditProperty(Properties.Resources.FirstName, student.FirstName, x => x);

            student.LastName = EditProperty(Properties.Resources.LastName, student.LastName, x => x);

            Func<string, DateTime> dateTimeConverter = input => DateTime.Parse(input);
            student.BirthDate = EditProperty(Properties.Resources.BirthDate, student.BirthDate, dateTimeConverter, x => x.ToShortDateString());
        }

        private static T EditProperty<T>(string name, T value, Func<string, T> stringToValueConverter, Func<T, string> valueToStringConverter = null)
        {
            Console.WriteLine(name);
            SendKeys.SendWait(valueToStringConverter?.Invoke(value) ?? value?.ToString() ?? "");
            string input = Console.ReadLine();

            try
            {
                return stringToValueConverter(input);
            }
            catch(FormatException exception)
            {
                Debug.WriteLine($"{exception.GetType().Name}: {exception.Message}");
                return EditProperty(name, value, stringToValueConverter, valueToStringConverter);
            }
        }

        //private static string EditProperty(string name, string value)
        //{
        //    Console.WriteLine(name);
        //    SendKeys.SendWait(value);
        //    return Console.ReadLine();
        //}

        private static void Delete()
        {
            var index = GetStudentIndex();
            //if(index != null)
            if(index.HasValue)
                Service.Delete(index.Value);
        }
    }
}
