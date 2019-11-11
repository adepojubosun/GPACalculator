using System.Linq;
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

        private Dictionary<int, string> GradeSelection = new Dictionary<int, string> {
              {1,"A"},{2,"A-"},{3,"B+"},{4,"B"},{5,"B-"},{6,"C+"},{7,"C"},{8,"C-"},{9,"D+"},{10,"D"},{11,"D-"},{12,"F"}
        };

        private readonly string _mainMenuOptions = $"Options:\n[0]Calculate CGPA\n[7]Add Year\n[8]Print to file\n[9]Quit";


        public void MainSemesterMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("-----------Welcome to GPA Calculator-----------\n----------Developed by Bosun----------");
            Console.WriteLine("");

            var isStatusComplete = false;
            int yearNumber = 1;
            Queue<Year> years = new Queue<Year>();



            while (!isStatusComplete)
            {

                var selection = 1;

                Console.WriteLine("");
                Console.WriteLine(_mainMenuOptions);
                Console.WriteLine("");


                try
                {
                    if (years.Any())
                    {


                        Console.WriteLine("Select Year:");
                        foreach (var year in years)
                        {
                            Console.WriteLine($"[{selection++}]{year.PrintYear()}");
                        }
                        Console.WriteLine("");
                    }
                    var input = Convert.ToInt32(Console.ReadLine());


                    switch (input)
                    {
                        case 0:
                            Console.WriteLine(CalculateCGPA(years.ToArray()));
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            continue;
                        case 1:
                            Console.WriteLine($"{years.ElementAt(0).PrintYear()}");
                            IEnumerable<Semester> yearSemesterOne = MainSemesterMenu(years.ElementAt(0));
                            years.ElementAt(0).AddSemesters(yearSemesterOne.ToArray());
                            continue;
                        case 2:
                            Console.WriteLine($"{years.ElementAt(1).PrintYear()}");
                            IEnumerable<Semester> yearSemesterTwo = MainSemesterMenu(years.ElementAt(1));
                            years.ElementAt(1).AddSemesters(yearSemesterTwo.ToArray());
                            continue;
                        case 3:
                            Console.WriteLine($"{years.ElementAt(2).PrintYear()}");
                            IEnumerable<Semester> yearSemesterThree = MainSemesterMenu(years.ElementAt(2));
                            years.ElementAt(2).AddSemesters(yearSemesterThree.ToArray());
                            continue;
                        case 4:
                            Console.WriteLine($"{years.ElementAt(3).PrintYear()}");
                            IEnumerable<Semester> yearSemesterFour = MainSemesterMenu(years.ElementAt(3));
                            years.ElementAt(3).AddSemesters(yearSemesterFour.ToArray());
                            continue;
                        case 5:
                            Console.WriteLine($"{years.ElementAt(4).PrintYear()}");
                            IEnumerable<Semester> yearSemesterFive = MainSemesterMenu(years.ElementAt(4));
                            years.ElementAt(4).AddSemesters(yearSemesterFive.ToArray());
                            continue;
                        case 6:
                            Console.WriteLine($"{years.ElementAt(5).PrintYear()}");
                            IEnumerable<Semester> yearSemesterSix = MainSemesterMenu(years.ElementAt(6));
                            years.ElementAt(6).AddSemesters(yearSemesterSix.ToArray());
                            continue;
                        case 7:
                            Year year = new Year(yearNumber++);
                            years.Enqueue(year);
                            continue;
                        case 9:
                            isStatusComplete = true;
                            Console.WriteLine("Goodbye");
                            break;
                        default:
                            Console.WriteLine("Invalid Input, try again");
                            continue;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, try again");
                    continue;
                }

            }

        }

        public IEnumerable<Semester> MainSemesterMenu(Year year)
        {
            var semestersTemp = new List<Semester>();
            var semesters = year.GetSemesters();

            var isComplete = false;

            Console.WriteLine("");

            while (!isComplete)
            {
                var counter = 1;
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine(year.PrintYear());
                    Console.WriteLine("------------------------------");
                    foreach (var semester in semesters)
                    {
                        Console.WriteLine($"[{counter++}]{semester.GetSemesterTypeName()}");
                    }
                    Console.WriteLine("[4]Go Back");

                    Console.WriteLine("------------------------------");
                    Console.WriteLine("");

                    var input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            semesters[0] = MainCourseMenu(semesters[0], year);
                            continue;
                        case 2:
                            semesters[1] = MainCourseMenu(semesters[1], year);
                            continue;
                        case 3:
                            semesters[2] = MainCourseMenu(semesters[2], year);
                            continue;
                        case 4:
                            isComplete = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Input, Try again");
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error, Try again");
                    continue;
                }

            }
            semestersTemp = semesters.ToList();
            return semestersTemp;
        }


        public Semester MainCourseMenu(Semester semester, Year year)
        {
            Semester semesterTemp = semester;
            List<Course> courses = semesterTemp.Courses;
            var isStatusComplete = false;
            while (!isStatusComplete)
            {

                var count = 1;

                Console.WriteLine("");
                Console.WriteLine($"{year.PrintYear()} - {semester.GetSemesterTypeName()}\n");
                Console.Write($"Courses Count {courses.Count}\n");
                Console.WriteLine("------------------------------");
                foreach (var course in courses)
                {
                    Console.WriteLine(count++ + ". " + course.PrintDetails());
                }

                Console.WriteLine("------------------------------");
                Console.WriteLine("");
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------");
                    
                    Console.Write($"\nSelect from Options:\n[1]Add Course\n[2]Calculate GPA\n[3]Go Back\n");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("");
                    var input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, Try again");
                    continue;
                }

            }
            return semesterTemp;
        }

        public Course AddCourseMenu()
        {
            var isStatusComplete = false;
            var title = "";
            var units = 0;
            Course course = null;
            Grade gradeSelect;
            while (!isStatusComplete)
            {
                try
                {
                    Console.WriteLine("CourseTitle:");
                    title = Console.ReadLine();
                    Console.WriteLine("Units:");
                    units = Convert.ToInt32(Console.ReadLine());
                    foreach (KeyValuePair<int, string> entry in GradeSelection)
                    {
                        Console.WriteLine("[" + entry.Key + "]." + entry.Value);
                    }
                    gradeSelect = new Grade(GradeSelection[Convert.ToInt32(Console.ReadLine())]);
                    if (units > 0 && gradeSelect != null)
                    {
                        course = new Course(title, gradeSelect, units);
                        isStatusComplete = true;
                    }
                    else
                    {
                        isStatusComplete = false;
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
            }
            return course;
        }

        public string CalculateGPA(Semester semester)
        {
            var creditsTotal = 0.00;
            var gradePointTotal = 0.00;
            List<Course> courseList = semester.Courses;
            foreach (var course in courseList)
            {
                creditsTotal += course.Units;
                gradePointTotal += course.GradePoint();
            }
            return String.Format("Your GPA for {0} is {1}", semester.GetSemesterTypeName(), gradePointTotal / creditsTotal);
        }

        public string CalculateCGPA(Year[] years)
        {
            var creditsTotal = 0.00;
            var gradePointTotal = 0.00;
            foreach (var year in years)
            {
                foreach (var semester in year.GetSemesters())
                {
                    foreach (var course in semester.Courses)
                    {
                        creditsTotal += course.Units;
                        gradePointTotal += course.GradePoint();
                    }
                }
            }
            return String.Format("Your overall CGPA {0}", gradePointTotal / creditsTotal);
        }

    }
}