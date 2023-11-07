using PetCare.Data;

namespace PetCare.Modules.Owner;

public class OwnerService : IOwnerService
{
    private readonly PetCareContext _context;

    public OwnerService(PetCareContext context)
    {
        _context = context;
    }

    public List<Owner> FindByLastName(string lastName)
    {
        var query = from owner in _context.Owners select owner;

        var owners = query.Where(
            owner => string.Equals(owner.LastName.ToLower(), lastName.ToLower())
        );

        return owners.ToList();
    }
}
