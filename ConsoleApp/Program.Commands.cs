using ConsoleApp.Models;
using Models;
using Services;
using Services.Interfaces;
using System;
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
            string indexString;
            int index;
            do {
                indexString = EditProperty(Properties.Resources.Index, student.Index.ToString());
            } while (indexString.Length != 6 || !int.TryParse(indexString, out index));
            student.Index = index;


            student.FirstName = EditProperty(Properties.Resources.FirstName, student.FirstName);
            
            student.LastName = EditProperty(Properties.Resources.LastName, student.LastName);

            string birthDateString;
            DateTime birthDate;
            do
            {
                birthDateString = EditProperty(Properties.Resources.BirthDate, student.BirthDate.ToShortDateString());
            } while (!DateTime.TryParse(birthDateString, out birthDate));
            student.BirthDate = birthDate;
        }

        private static string EditProperty(string name, string value)
        {
            Console.WriteLine(name);
            SendKeys.SendWait(value);
            return Console.ReadLine();
        }

        private static void Delete()
        {
            var index = GetStudentIndex();
            //if(index != null)
            if(index.HasValue)
                Service.Delete(index.Value);
        }
    }
}
