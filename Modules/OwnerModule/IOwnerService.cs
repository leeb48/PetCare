using PetCare.Modules.OwnerModule.DTO;
using PetCare.Modules.PetModule;

namespace PetCare.Modules.OwnerModule;

public interface IOwnerService
{
    public OwnerDTO CreateOwner(OwnerDTO ownerDTO);
    public Owner UpdateOwner(int id, Owner ownerDTO);
    public void RemoveOwner(int id);
    public Owner AddPet(int id, Pet pet);
    public Owner? FindById(int id);
    public IEnumerable<OwnerDTO> FindByLastName(string lastName);
    public IEnumerable<Owner> FindByBirthdate(DateTime birthdate);
}
