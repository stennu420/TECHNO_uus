using System.ComponentModel.DataAnnotations;

namespace Techno_uus.Models
{
    public class Mentor
    {
<<<<<<< Updated upstream
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string  Email { get; set; }
        public bool IsFired { get; set; }
        
=======
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int id { get; set; }
        public int NationalIdentitiCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public bool isFired { get; set; }
>>>>>>> Stashed changes
    }
}
