using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using PetCare.Data;
using PetCare.Modules.PetModule;

namespace PetCare.Modules.OwnerModule;

public class OwnerService : IOwnerService
{
    private readonly PetCareContext _context;

    public OwnerService(PetCareContext context)
    {
        _context = context;
    }

    public Owner CreateOwner(Owner newOwner)
    {
        _context.Owners.Add(newOwner);
        _context.SaveChanges();

        return newOwner;
    }

    public Owner UpdateOwner(int id, Owner owner)
    {
        owner.Id = id;
        _context.Owners.Update(owner);
        _context.SaveChanges();

        return owner;
    }

    public void RemoveOwner(int id)
    {
        var owner = FindById(id);

        if (owner != null)
        {
            _context.Owners.Remove(owner);
            _context.SaveChanges();
        }
    }

    public Owner AddPet(int id, Pet pet)
    {
        throw new NotImplementedException();
    }

    public Owner? FindById(int id)
    {
        return _context.Owners.FirstOrDefault(owner => owner.Id == id);
    }

    public IEnumerable<Owner> FindByBirthdate(DateTime birthdate)
    {
        var query = from owner in _context.Owners select owner;

        var owners = query
            .Where(owner => owner.Birthdate == birthdate)
            .Include(owner => owner.Pets);

        return owners;
    }

    public IEnumerable<Owner> FindByLastName(string lastName)
    {
        var query = from owner in _context.Owners select owner;

        var owners = query
            .Where(owner => string.Equals(owner.LastName!.ToLower(), lastName.ToLower()))
            .Include(owner => owner.Pets);

        return owners;
    }
}
