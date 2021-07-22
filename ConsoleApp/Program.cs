using ConsoleApp.Models;
using Models;
using Services;
using Services.Interfaces;
using System;
using System.Windows.Forms;

namespace ConsoleApp
{
    static class Program
    {
        private static IStudentsService Service { get; } = new StudentsService();

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                DisplayStudents();
            } while (ReadAndExecuteCommand());
        }

        private static bool ReadAndExecuteCommand()
        {
            if (Enum.TryParse<Commands>(Console.ReadLine(), true, out var command)) {
                switch (command)
                {
                    case Commands.exit:
                        return false;
                    case Commands.delete:
                        Delete();
                        break;
                    case Commands.update:
                        Update();
                        break;
                    case Commands.create:
                        Create();
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

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

        //private static Nullable<int> GetStudentIndex()
        private static int? GetStudentIndex()
        {
            string input;
            Console.WriteLine(Properties.Resources.ProvideIndex);
            input = Console.ReadLine();
            //var index = int.Parse(input);
            if (int.TryParse(input, out var index))
                return index;
            return null;
        }

        private static void DisplayStudents()
        {
            foreach(var student in Service.Read())
            {
                //var info = student.Index + "\t" + student.FirstName + "\t" + student.LastName + "\t" + student.BirthDate.ToShortDateString();
                //var info = string.Format("{0}\t{2}\t{1}\t{3}", student.Index, student.LastName, student.FirstName, student.BirthDate.ToShortDateString());
                //Console.WriteLine(info);
                //Console.WriteLine("{0}\t{2}\t{1}\t{3}", student.Index, student.LastName, student.FirstName, student.BirthDate.ToShortDateString());
                //Console.WriteLine("{0, 6}\t{2, 10}\t{1, 10}\t{3, 10}", student.Index, student.LastName, student.FirstName, student.BirthDate.ToShortDateString());
                //Console.WriteLine("{0, -6}\t{2, -10}\t{1, -10}\t{3, -10}", student.Index, student.LastName, student.FirstName, student.BirthDate.ToShortDateString());
                Console.WriteLine($"{student.Index, -6}\t{student.FirstName, -10}\t{student.LastName, -10}\t{student.BirthDate.ToString("d"), -10}");
            }
        }
    }
}
