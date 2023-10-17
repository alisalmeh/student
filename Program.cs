﻿using System;
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
                                        .Select(x => x.StudentName);

            Console.WriteLine("First query result is: ");

            foreach (var item in firstQuery)
            {
                Console.WriteLine(item);
            }

            // score > 80 || CA city -> just their names 
            var secondQuery = studentList.Where(s => s.Score > 80 || s.City == "CA")
                                         .Select(x => x.StudentName);

            Console.WriteLine("\nSecond query results are: ");

            foreach (var item in secondQuery)
            {
                Console.WriteLine(item);
            }
        }
    }
}
