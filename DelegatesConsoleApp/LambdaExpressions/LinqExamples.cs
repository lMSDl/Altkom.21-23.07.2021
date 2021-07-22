using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp.LambdaExpressions
{
    public class LinqExamples
    {
        static Student someStudent = new Student { FirstName = "Kamila", LastName = "Ewowska", BirthDate = new DateTime(1934, 1, 1), Index = 678901 };

        int[] numbers = new[] { 1, 3, 4, 2, 5, 7, 8, 6, 9, 0 };
        List<string> strings = "wlazł kotek na płotek i mruga".Split(' ').ToList();

        List<Student> students = new List<Student>
        {
            new Student("Adam", "Adamski", new DateTime(1978, 2, 21), 123456 ),
            new Student { LastName = "Ewowska", FirstName = "Ewa",  BirthDate = new DateTime(2000, 1, 1), Index = 234567  } ,
            new Student { Index = 345678, FirstName = "Adam", LastName = "Ewowska", BirthDate = new DateTime(1978, 2, 21),  },
            new Student { FirstName = "Ewa", LastName = "Adamska", BirthDate = new DateTime(1994, 1, 1), Index = 456789  } ,
            new Student { FirstName = "Piotr", LastName = "Adamski", BirthDate = new DateTime(1978, 2, 21), Index = 567890 },
            someStudent,
        };


        public void Test()
        {
            var queryResult1 = from item in numbers where item > 4 select item;
            var queryResult2 = numbers.Where(item => item > 4);
            var queryResult3 = numbers.Where(item => item > 4).Where(x => x < 7);
            var queryResult4 = numbers.Where(item => item > 5).OrderBy(x => x);
            var queryResult5 = numbers.Where(item => item > 5).OrderByDescending(x => x);
            var queryResult6 = numbers.Where(item => item > 4 && item < 7);
            var queryResult7 = numbers.Where(item => item < 4 || item > 7).ToList();

            var queryResult8 = strings.Where(x => x.Length == 5).Select(x => x.ToUpper()).ToList();
            var queryResult9 = strings.Select(x => x.Length).ToList();
            
            var queryResult10 = students.Where(x => x.FirstName == "Ewa").Select(x =>
            {
                var item = $"{x.LastName} {x.Index}";
                return item;
            }).ToList();


            // wybierz studentów o imieniu Ewa

            // Wybierz studentów urodzonych przed 1990 rokiem

            // wybierz pierwszego studenta, który ma w nazwisku "Adam" i jest kobietą

            // posortuj studentów po nazwisku a następnie o imieniu

            // wybierz datę urodzenia najmłodszego studenta

            // podaj średni wiek studentów
        }
    }
}
