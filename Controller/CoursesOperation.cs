using System.Collections.Generic;
using System;
using GPACalculator.Model;

namespace GPACalculator.Controller
{
    public class CoursesOperation 
    {
        public CoursesOperation()
        {

        }

        private Dictionary<int,string> GradeSelection = new Dictionary<int,string> {
              {1,"A"},{2,"A-"},{3,"B+"},{4,"B"},{5,"B-"},{6,"C+"},{7,"C"},{8,"C-"},{9,"D+"},{10,"D"},{11,"D-"},{12,"F"}
        };


        public void MainSemesterMenu()
        {
            var isStatusComplete = false;
            int yearNumber = 1;
            Year year = new Year(yearNumber);
            Semester semesterFall = new Semester(SemesterType.Fall);
            Semester semesterSummer = new Semester(SemesterType.Summer);
            Semester semesterSpring = new Semester(SemesterType.Spring);
            Queue<Year> years = new Queue<Year>();
            years.Enqueue(year);
            Year[] yearArr = years.ToArray();
            while(!isStatusComplete)
            {
                Console.WriteLine("Select from Options:\n[0]Calculate CGPA");
                Console.WriteLine("[16]Add New Year");
                Console.WriteLine("[17]Quit");

                var yearCount = 1; 
                foreach(var yeartemp in years){
                Console.WriteLine(yeartemp.PrintYear()+"\n["+yearCount+++"]Fall Semester\n ["+yearCount+++"]Spring Semester\n ["+yearCount+++"]Summer Semester\n");
                }
                var input = Convert.ToInt32(Console.ReadLine());
                switch(input)
                {
                    case 1:
                    case 4:
                    case 7:
                    case 10:
                    case 13:
                    var semester = MainCourseMenu(semesterFall);
                    semesterFall = semester;
                    continue;
                    case 2:
                    case 5:
                    case 8:
                    case 11:
                    case 14:
                    semesterSpring = MainCourseMenu(semesterSpring);
                    continue;
                    case 3:
                    case 6:
                    case 9:
                    case 12:
                    case 15:
                    semesterSummer = MainCourseMenu(semesterSummer);
                    continue;
                    case 16:
                    ++yearNumber;
                    Year year2 = new Year(yearNumber);
                    years.Enqueue(year2);
                    continue;
                    case 17:
                    Console.WriteLine("goodbye!");
                    isStatusComplete = true;
                    break;
                    default:
                    Console.WriteLine("Invalid Input");
                    continue;
                }
            }
 
        }

        public Semester MainCourseMenu(Semester semester){
        Semester semesterTemp = semester;
        List<Course> courses = semesterTemp.Courses;
        var isStatusComplete = false;
        while(!isStatusComplete)
        {
            Console.WriteLine($"Courses Count {courses.Count}\n");
            var count = 1;
            foreach(var course in courses)
            {
            Console.WriteLine(count+++". "+course.PrintDetails());
            }
            try
            {
            Console.WriteLine("Select from Options:\n [1]Add Course\n [2]Calculate GPA\n [3]Go Back");
            var input = Convert.ToInt32(Console.ReadLine());
            switch(input)
            {
                case 1: 
                Course course = AddCourseMenu();
                semesterTemp.AddCourse(course);
                continue;
                case 2: 
                Console.WriteLine(CalculateGPA(semester));
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                continue;
                case 3: 
                isStatusComplete = true;
                break;
                default:
                Console.Write("Invalid Option");
                continue;    
            }
            }catch( Exception e)
            {
                Console.WriteLine("Error, Try again");
            }

        }
        return semesterTemp;
        }

        public Course AddCourseMenu(){
            var isStatusComplete = false;
            var title = "";
            var units = 0;
            Course course = null;
            Grade gradeSelect;
            while(!isStatusComplete)
            {
                try {
                    Console.WriteLine("CourseTitle:");
                    title = Console.ReadLine();
                    Console.WriteLine("Units:");
                    units = Convert.ToInt32(Console.ReadLine());
                    foreach(KeyValuePair <int,string> entry in GradeSelection)
                    {
                        Console.WriteLine("["+entry.Key+"]."+entry.Value);
                    }
                     gradeSelect = new Grade(GradeSelection[Convert.ToInt32(Console.ReadLine())]);
                     if(units > 0 && gradeSelect != null){
                         course = new Course(title,gradeSelect,units);
                         isStatusComplete = true;
                     }else{
                         isStatusComplete = false;
                         continue;
                     }
                }catch(Exception e){
                    Console.WriteLine(e);
                    continue;
                }
            }
            return course;
        }

        public string CalculateGPA(Semester semester){
            var creditsTotal = 0.00;
            var gradePointTotal = 0.00;
            List<Course> courseList = semester.Courses;
            foreach(var course in courseList)
            {
                creditsTotal+= course.Units;
                gradePointTotal+= course.GradePoint();
            }
            return String.Format("Your GPA for {0} is {1}",semester.GetSemesterTypeName(), gradePointTotal/creditsTotal);
        }

        public string CalculateCGPA(Year[] years){
            var creditsTotal = 0.00;
            var gradePointTotal = 0.00;
            foreach(var year in years){
                foreach(var semester in year.GetSemesters()){
                    foreach(var course in semester.Courses){
                        creditsTotal+= course.Units;
                        gradePointTotal+= course.GradePoint();
                    }
                }
            }
            return String.Format("Your overall CGPA {0}",gradePointTotal/creditsTotal);
        }
        
    }
}