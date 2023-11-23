using System.ComponentModel.DataAnnotations;
using PetCare.Models;
using PetCare.Modules.PetModule;

namespace PetCare.Modules.OwnerModule;

public class Owner : BaseEntity
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Address { get; set; }

    public required string State { get; set; }
    public required string City { get; set; }

    [MaxLength(10)]
    public required string PhoneNumber { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [DataType(DataType.Date)]
    public DateOnly Birthdate { get; set; }

    public ICollection<Pet>? Pets { get; set; }
}
