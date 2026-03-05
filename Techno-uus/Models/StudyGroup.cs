using System;
using System.ComponentModel.DataAnnotations;
using static Techno_uus.Models.StudyGroup;

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

        public class StudyGroups
        {
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; } = "";

            [DataType(DataType.Date)]
            public DateTime StudyStart { get; set; }

            [DataType(DataType.Date)]
            public DateTime StudyEnd { get; set; }

            //Juhtõpilane Pupils tabelist
            [Required]
            public int LeaderPupilId { get; set; }
            public Pupil? LeaderPupil { get; set; }
            [StringLength(200)]
            public string? ClassroomInfo { get; set; }

            // plus1 andmetüüp 
            public StudyGroupLevel Level { get; set; }
        }
    }
}
