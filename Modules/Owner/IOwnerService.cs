namespace PetCare.Modules.Owner;

public interface IOwnerService
{
    public List<Owner> FindByLastName(string lastName);
}
