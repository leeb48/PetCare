using PetCare.Models;

namespace PetCare.Modules.Owner
{
    public class Owner : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        // TODO: list of pets
    }
}
