namespace GPACalculator.Model
{
    public class Year
    {
        private Semester[] Semesters;
        private int YearNumber;


        public Year(int year){
            this.Semesters = new Semester[3] {new Semester(SemesterType.Fall),new Semester(SemesterType.Spring), new Semester(SemesterType.Summer)};
            this.YearNumber = year;
        }

        public void AddSemester(Semester semester){
            Semesters[(int)(semester.SemType - 1)] = semester;
        }

        public Semester[] GetSemesters(){
            return Semesters;
        }

        public Semester getSemester(int semester){
            return Semesters[semester];
        }

        public void AddSemesters(Semester[] semesters)
        {
            this.Semesters = semesters;
        }

        public string PrintYear(){
            return "Year "+YearNumber+"";
        }
    }
}