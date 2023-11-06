using System.ComponentModel.DataAnnotations;
using PetCare.Models;

namespace PetCare.Pet;

public class Pet : BaseEntity
{
    public string? Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }
}
