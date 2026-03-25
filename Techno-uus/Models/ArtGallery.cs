namespace Techno_uus.Models
{
    public class ArtGallery
    {
        public int Id { get; set; }

        public string PupilName { get; set; }

        public string? PupilId { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateOnly CreationDate { get; set; }

        public string ImagePath { get; set; }

        public string? Description { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
