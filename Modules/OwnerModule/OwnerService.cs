using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetCare.Data;
using PetCare.Modules.OwnerModule.DTO;
using PetCare.Modules.PetModule;
using PetCare.Modules.PetModule.DTO;

namespace PetCare.Modules.OwnerModule;

public class OwnerService : IOwnerService
{
    private readonly PetCareContext _context;
    private readonly IMapper _mapper;

    public OwnerService(PetCareContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public OwnerDTO CreateOwner(OwnerDTO ownerDTO)
    {
        var newOwner = _mapper.Map<Owner>(ownerDTO);

        _context.Owners.Add(newOwner);
        _context.SaveChanges();

        return ownerDTO;
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
            .Include(owner => owner.Pets!)
            .ThenInclude(pet => pet.PetType);

        return owners;
    }

    public IEnumerable<OwnerDTO> FindByLastName(string lastName)
    {
        var query = from owner in _context.Owners select owner;

        var owners = query
            .Where(owner => string.Equals(owner.LastName!.ToLower(), lastName.ToLower()))
            .Include(owner => owner.Pets!)
            .ThenInclude(pet => pet.PetType)
            .Select(
                owner =>
                    new OwnerDTO
                    {
                        Id = owner.Id,
                        FirstName = owner.FirstName,
                        LastName = owner.LastName,
                        Pets = owner.Pets!
                            .Select(
                                pet => new PetDTO { Name = pet.Name, PetType = pet.PetType.Name }
                            )
                            .ToList()
                    }
            );

        return owners;
    }
}
