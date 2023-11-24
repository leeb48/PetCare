using PetCare.Modules.OwnerModule.DTO;

namespace PetCare.Modules.OwnerModule;

public interface IOwnerService
{
    public IEnumerable<OwnerDTO> GetOwners(int count);
    public CreateOwnerDTO CreateOwner(CreateOwnerDTO createOwnerDTO);
    public CreateOwnerDTO UpdateOwner(int id, CreateOwnerDTO ownerDTO);
    public void RemoveOwner(int id);
    public Owner? FindById(int id);
    public OwnerDTO? FindByIdDTO(int id);
    public IEnumerable<OwnerDTO> FindByBirthdate(DateOnly birthdate);
    public IEnumerable<OwnerDTO> FindByLastName(string lastName);
}
