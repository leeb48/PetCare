namespace PetCare.Modules.PetModule.DTO;

public class PetDTO
{
    public required string Name { get; set; }
    public required DateOnly Birthdate { get; set; }
    public required string PetTypeName { get; set; }
}
