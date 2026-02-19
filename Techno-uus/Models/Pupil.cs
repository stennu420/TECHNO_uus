namespace Techno_uus.Models
{
    public class Pupil
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HasEnrolleddAt { get; set; }
        public DateTime DayOfBirth { get; set; }
        public EducationLevel Grade { get; set; }

        public string PhoneNumber { get; set; }
        public int PostCode { get; set; }
        public string GamerTag { get; set; }
    }
    public enum EducationLevel 
    {
        FirstGrade, SecondGrade, ThirdGrade,FortGrade,FiftGrade,SixGrade,SeventGrade,EightGrade,NigtGrade,ThentGrade,ElevntGrade,TwelvftGrade 
        
    }
}
