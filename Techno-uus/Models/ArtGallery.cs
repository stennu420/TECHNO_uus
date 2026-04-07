using System.ComponentModel.DataAnnotations;


namespace Techno_uus.Models
{
    public class ArtGallery
    {
        [Key]
        public Guid ArtId { get; set; }

        public string PupilName { get; set; }

        public string? PupilId { get; set; }

        public string ArtWorkTitle { get; set; } 
        public string ArtWorkDescription { get; set; }
        public string? Image { get; set; }
       
        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public DateTime SubmittedAt  { get; set; }

        public DateOnly CreationDate { get; set; }
    }
}
