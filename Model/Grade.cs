using System;
using System.Collections.Generic;

namespace GPACalculator.Model
{
    public class Grade
    {
        private string GradeVal;
        private double GradePoint;
        public static Dictionary<string,double> Grades{get {
            return new Dictionary<string, double> {
                {"A",4.00}, {"A-",3.70}, {"B+",3.33},
                {"B",3.00}, {"B-",2.70}, {"C+",2.30},
                {"C",2.00}, {"C-",1.70}, {"D+",1.30},
                 {"D",1.00}, {"D-",0.70} ,{"F", 0.00}
            };
        }}

        public Grade(string grade)
        {
            this.GradeVal = grade;
            this.GradePoint = Grades[grade];
        }

        public double GetGradePoint(){
            return GradePoint;
        }

        public string GetGradeVal(){
            return GradeVal;
        }

    }
}