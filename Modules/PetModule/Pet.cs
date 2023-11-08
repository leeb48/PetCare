using System.ComponentModel.DataAnnotations;
using PetCare.Models;

namespace PetCare.Modules.PetModule;

public class Pet : BaseEntity
{
    public string? Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Birthdate { get; set; }
}
