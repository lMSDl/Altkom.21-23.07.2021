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
