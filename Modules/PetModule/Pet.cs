using System.ComponentModel.DataAnnotations;
using PetCare.Models;
using PetCare.Modules.OwnerModule;

namespace PetCare.Modules.PetModule;

public class Pet : BaseEntity
{
    [Required]
    public required string Name { get; set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTime Birthdate { get; set; }

    [Required]
    public required PetType PetType { get; set; }

    public int OwnerId { get; set; }
}
