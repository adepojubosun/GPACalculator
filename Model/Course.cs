using System;

namespace GPACalculator.Model
{
    public class Course
    {
        private string CourseTitle;
        private Grade grade;
        public int Units {get;}

        public Course(string title, Grade grade, int units){
            this.grade = grade;
            this.CourseTitle = title;
            this.Units = units;
        }

        public double GradePoint(){
            return grade.GetGradePoint() * Units;
            
        }

        public string PrintDetails(){
            var displayString = String.Format($"{CourseTitle} - {Units} Units - Current Grade: {grade.GetGradeVal()}");
            return displayString;
        }

    }
}