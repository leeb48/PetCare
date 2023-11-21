using System.ComponentModel.DataAnnotations;

namespace PetCare.Modules.PetModule.DTO;

public class PetDTO
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public DateOnly Birthdate { get; set; }

    [Required]
    public string? PetTypeName { get; set; }
}
