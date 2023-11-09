using System.ComponentModel.DataAnnotations;
using PetCare.Models;
using PetCare.Modules.PetModule;

namespace PetCare.Modules.OwnerModule;

public class Owner : BaseEntity
{
    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? Address { get; set; }

    [Required]
    public string? State { get; set; }

    [Required]
    public string? PhoneNumber { get; set; }

    [Required]
    public string? Email { get; set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTime? Birthdate { get; set; }

    public ICollection<Pet>? Pets { get; set; }
}
