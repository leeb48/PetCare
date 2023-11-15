using PetCare.Modules.OwnerModule.DTO;
using PetCare.Modules.PetModule.DTO;

namespace PetCare.Modules.OwnerModule;

public interface IOwnerService
{
    public CreateOwnerDTO CreateOwner(CreateOwnerDTO createOwnerDTO);
    public OwnerDTO UpdateOwner(int id, OwnerDTO ownerDTO);
    public void RemoveOwner(int id);
    public Owner AddPet(int id, PetDTO petDTO);
    public Owner? FindById(int id);
    public IEnumerable<OwnerDTO> FindByBirthdate(DateOnly birthdate);
    public IEnumerable<OwnerDTO> FindByLastName(string lastName);
}
