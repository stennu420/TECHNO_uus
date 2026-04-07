using System.ComponentModel.DataAnnotations;

namespace Techno_uus.Models
{
    public class ArtGalleryListImageViewModel
    {
        [Key]
        public Guid ImageID { get; set; }
        public string Image { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? ListID { get; set; }
    }
}
