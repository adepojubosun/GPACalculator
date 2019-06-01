namespace GPACalculator.Model
{
    public class Year
    {
        private Semester[] Semester;
        private int YearNumber;


        public Year(int year){
            this.Semester = new Semester[3];
            this.YearNumber = year;
        }

        public void AddSemesters(Semester semester){
            Semester[(int)(semester.SemType - 1)] = semester;
        }

        public Semester[] GetSemesters(){
            return Semester;
        }

        public Semester getSemester(int semester){
            return Semester[semester];
        }

        public string PrintYear(){
            return "Year "+YearNumber+"";
        }
    }
}