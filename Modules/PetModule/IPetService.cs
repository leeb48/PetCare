using PetCare.Modules.PetModule.DTO;

namespace PetCare.Modules.PetModule;

public interface IPetService
{
    public Pet CreatePet(int ownerId, PetDTO petDTO);
}
