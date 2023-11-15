namespace PetCare.Modules.PetModule.DTO;

public class PetDTO
{
    public required string Name { get; set; }
    public DateOnly Birthdate { get; set; }
    public required string PetType { get; set; }
}
