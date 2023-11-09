using System.ComponentModel.DataAnnotations;
using PetCare.Models;

namespace PetCare.Modules.PetModule;

public class Pet : BaseEntity
{
    public required string Name { get; set; }

    [DataType(DataType.Date)]
    public required DateTime Birthdate { get; set; }
}
