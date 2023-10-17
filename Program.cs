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

            PrintQueryResult(firstQuery, "First");

            // score > 80 || CA city -> just their names 
            var secondQuery = studentList.Where(s => s.Score > 80 || s.City == "CA")
                                         .Select(s => s.StudentName);

            PrintQueryResult(secondQuery, "Second");

            // Name started with 'B' then projected to MinimalStudent Class
            var thirdQuery = studentList.Where(s => s.StudentName.ToUpper().StartsWith('B'))
                                        .Select(s => new MinimalStudent()
                                        {
                                            StudentName = s.StudentName
                                        })
                                        .Select(s => s.StudentName);

            PrintQueryResult(thirdQuery, "Third");

            // NotActive students ordered descending by score
            var fourthQuery = studentList.Where(s => !s.IsActive)
                                         .OrderByDescending(s => s.Score)
                                         .Select(s => s.StudentName);

            PrintQueryResult(fourthQuery, "Fourth");

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

        private static void PrintQueryResult<T>(IQueryable<T> queryResult, string queryName)
        {
            Console.WriteLine($"\n{queryName} query result: ");

            foreach (var item in queryResult)
            {
                Console.WriteLine(item);
            }
        }
    }
}
