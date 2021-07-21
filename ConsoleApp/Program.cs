using ConsoleApp.Models;
using Services;
using Services.Interfaces;
using System;

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
                        break;
                    case Commands.create:
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        private static void Delete()
        {
            string input;
            Console.WriteLine(Properties.Resources.ProvideIndex);
            input = Console.ReadLine();
            //var index = int.Parse(input);
            if (int.TryParse(input, out var index))
                Service.Delete(index);
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
                Console.WriteLine($"{student.Index, -6}\t{student.FirstName, -10}\t{student.LastName, -10}\t{student.BirthDate.ToShortDateString(), -10}");
            }
        }
    }
}
