namespace Techno_uus.Models
{
    public class ArtGallery
    {

        public int Id { get; set; }

        public string PupilName { get; set; }

        public string? PupilId { get; set; }

        public string ArtWorkTitle { get; set; } 
        public string ArtWorkDDescription { get; set; }

        public IFormFile Image { get; set; }

        public string ImagePath { get; set; }

        public string? Description { get; set; }

        public DateTime SubmittedAt { get; set; }

        public DateOnly CreationDate { get; set; }
    }
}
