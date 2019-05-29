using System;
using System.Collections.Generic;

namespace GPACalculator.Model
{
    public class Semester
    {
        public SemesterType SemType {get; set;}
        public List<Course> Courses {get;}

        public Semester(SemesterType type){
            this.SemType = type;
            this.Courses = new List<Course>();
        }

        public void AddCourse(Course course){
            this.Courses.Add(course);
        }

        public string GetSemesterTypeName(){
            var typeName = "";
            switch(SemType){
                case SemesterType.Fall:
                typeName+="Fall";
                break;
                case SemesterType.Spring:
                typeName+="Spring";
                break;
                case SemesterType.Summer:
                typeName+="Summer";
                break;
                default:
                break;
            }
            return typeName+" Semester";
        }
    }

        public enum SemesterType : int 
        {
            Fall = 1, Spring = 2, Summer = 3
        }
}