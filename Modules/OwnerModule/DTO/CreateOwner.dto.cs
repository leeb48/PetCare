using System.ComponentModel.DataAnnotations;
using PetCare.Modules.PetModule.DTO;

namespace PetCare.Modules.OwnerModule.DTO;

public class CreateOwnerDTO
{
    public int? Id { get; set; }

    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required]
    public required string Address { get; set; }

    [Required]
    public required string State { get; set; }

    [Required]
    public required string PhoneNumber { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public DateOnly? Birthdate { get; set; }
    public IList<PetDTO>? Pets { get; set; }
}
