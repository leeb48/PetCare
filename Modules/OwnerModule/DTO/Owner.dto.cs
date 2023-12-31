using System.ComponentModel.DataAnnotations;
using PetCare.Modules.PetModule.DTO;

namespace PetCare.Modules.OwnerModule.DTO;

public class OwnerDTO
{
    public int? Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PhoneNumber { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public DateOnly? Birthdate { get; set; }
    public IList<PetDTO>? Pets { get; set; }

    public string GetFullAddress()
    {
        return $"{Address}, {City}, {State}";
    }
}
