using System.ComponentModel.DataAnnotations;
using PetCare.Modules.PetModule.DTO;

namespace PetCare.Modules.OwnerModule.DTO;

public class CreateOwnerDTO
{
    public int? Id { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? Address { get; set; }

    [Required]
    public string? City { get; set; }

    [Required]
    public string? State { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 10)]
    public string? PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public DateOnly? Birthdate { get; set; }
    public IList<PetDTO>? Pets { get; set; }
}
