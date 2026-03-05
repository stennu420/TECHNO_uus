namespace Techno_uus.Models
{
    public class StudyGroup
    {
        public int Id { get; set; }

        // Grupi nimi
        public string GroupName { get; set; }

        //Õpingute algus ja lõpp
        public DateTime StudyStart { get; set; }
        public DateTime StudyEnd { get; set; }

        //Juhtõpilane 
        public int LeaderPupilId { get; set; }
        public Pupil? LeaderPupil { get; set; }

        // Klassiruumi info
        public string? ClassroomInfo { get; set; }

        // Oma andmetüüp
        public StudyGroupLevel Level { get; set; }

    }
    public enum StudyGroupLevel
    {
        Beginner, Intermediate, Advanced
    }
}
