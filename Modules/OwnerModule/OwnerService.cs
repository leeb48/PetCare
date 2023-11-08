using Microsoft.EntityFrameworkCore;
using PetCare.Data;

namespace PetCare.Modules.OwnerModule;

public class OwnerService : IOwnerService
{
    private readonly PetCareContext _context;

    public OwnerService(PetCareContext context)
    {
        _context = context;
    }

    public IEnumerable<Owner> FindByLastName(string lastName)
    {
        var query = from owner in _context.Owners select owner;

        var owners = query
            .Where(owner => string.Equals(owner.LastName.ToLower(), lastName.ToLower()))
            .Include(owner => owner.Pets);

        return owners;
    }
}
