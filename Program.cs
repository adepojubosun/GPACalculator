using System;
using System.Collections.Generic;
using GPACalculator.Model;
using GPACalculator.Controller;

namespace GPACalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CoursesOperation op = new CoursesOperation();
            op.MainSemesterMenu();
        }

    }
}
