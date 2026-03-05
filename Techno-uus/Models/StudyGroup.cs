using System;
using System.ComponentModel.DataAnnotations;

namespace Techno_uus.Models
{
    public class StudyGroup
    {
        public enum StudyGroupLevel
        {
            Algaja = 0,
            Kesktase = 1,
            Edasijõudnud = 2
        }

        public class StudyGroup
        {
            public int Id { get; set; }
            [Required]
            [StringLenght(100)]
            public string Name { get; set; } = "";

            public DateTime StudyEnd { get; set; }

            //Juhtõpilane Pupils tabelist
            public int LeaderPupilId { get; set; }
            public Pupil? LeaderPupil { get; set; }

            public string? ClassroomInfo { get; set; }

            // plus1 andmetüüp 
            public StudyGroupLevel1 {get; set; }
        }
    }
}
