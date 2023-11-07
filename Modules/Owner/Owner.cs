using System.ComponentModel.DataAnnotations;
using PetCare.Models;

namespace PetCare.Modules.Owner
{
    public class Owner : BaseEntity
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        // TODO: list of pets
    }
}
