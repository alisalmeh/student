using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliSalmeh_ProjectWeek12_LinqPractice
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Score { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }

    public class MinimalStudent
    {
        public string StudentName { get; set; }
    }
}