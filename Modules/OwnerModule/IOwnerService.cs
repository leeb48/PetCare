namespace PetCare.Modules.OwnerModule;

public interface IOwnerService
{
    public IEnumerable<Owner> FindByLastName(string lastName);
}
