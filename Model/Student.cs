namespace GPACalculator.Model
{
    public class Student
    {

        
        public string FirstName { get; set; }

        public string LastName {get; set;}

        public string Major {get; set; }

        public string CollegeName {get; set; }

        public string FullName { get { return FirstName+" "+LastName;}}

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName; 
        }
        
    }
}