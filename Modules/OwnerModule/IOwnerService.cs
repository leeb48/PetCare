using PetCare.Modules.PetModule;

namespace PetCare.Modules.OwnerModule;

public interface IOwnerService
{
    public Owner CreateOwner(Owner newOwner);
    public Owner UpdateOwner(int id, Owner owner);
    public void RemoveOwner(int id);
    public Owner AddPet(int id, Pet pet);
    public Owner? FindById(int id);
    public IEnumerable<Owner> FindByLastName(string lastName);
    public IEnumerable<Owner> FindByBirthdate(DateTime birthdate);
}
