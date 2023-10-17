using System;
using System.Linq;

namespace AliSalmeh_ProjectWeek12_LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentList = StudentDatabase.GetStudentsFromDb();

            // Active students && score > 80 && NYC city
            var firstQuery = studentList.Where(s => s.IsActive && s.Score > 80 && s.City == "NYC")
                                        .Select(s => s.StudentName);

            Console.WriteLine("First query result: ");

            foreach (var item in firstQuery)
            {
                Console.WriteLine(item);
            }

            // score > 80 || CA city -> just their names 
            var secondQuery = studentList.Where(s => s.Score > 80 || s.City == "CA")
                                         .Select(s => s.StudentName);

            Console.WriteLine("\nSecond query result: ");

            foreach (var item in secondQuery)
            {
                Console.WriteLine(item);
            }

            // NotActive students ordered descending by score
            var fourthQuery = studentList.Where(s => !s.IsActive)
                                         .OrderByDescending(s => s.Score)
                                         .Select(s => s.StudentName);

            Console.WriteLine("\nFourth query result: ");

            foreach (var item in fourthQuery)
            {
                Console.WriteLine(item);
            }

            // Average of class score
            var fifthQuery = studentList.Average(s => s.Score);

            Console.WriteLine($"\nAverage score of the class is: {fifthQuery}");

            // Average score of students in CA && Active && ('D' || 'R' in their names)
            var sixthQuery = studentList.Where(s => s.City == "CA" &&
                                                    s.IsActive &&
                                                    (s.StudentName.ToUpper().Contains('D') ||
                                                    s.StudentName.ToUpper().Contains('R')))
                                        .Average(s => s.Score);

            Console.WriteLine("\nAverage score of CA students with 'D' or 'R' in their names who are active is: " +
                                sixthQuery);

        }
    }
}
