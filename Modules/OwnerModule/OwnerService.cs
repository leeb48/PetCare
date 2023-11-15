using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

    public CreateOwnerDTO CreateOwner(CreateOwnerDTO createOwnerDTO)
    {
        var newOwner = _mapper.Map<Owner>(createOwnerDTO);

        _context.Owners.Add(newOwner);
        _context.SaveChanges();

        createOwnerDTO.Id = newOwner.Id;

        return createOwnerDTO;
    }

    public OwnerDTO UpdateOwner(int id, OwnerDTO ownerDTO)
    {
        var owner = FindById(id) ?? throw new Exception("Owner not found");

        foreach (var dtoProp in typeof(OwnerDTO).GetProperties())
        {
            var dtoValue = dtoProp.GetValue(ownerDTO);

            var ownerProp = typeof(Owner).GetProperty(dtoProp.Name);

            if (dtoValue != null && ownerProp != null)
            {
                ownerProp.SetValue(owner, dtoValue);
            }
        }

        _context.SaveChanges();

        ownerDTO = _mapper.Map<OwnerDTO>(owner);

        return ownerDTO;
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

    public Owner AddPet(int id, PetDTO petDTO)
    {
        // link pet and user
        // when we see a new pet type, create one
        throw new NotImplementedException();
    }

    public OwnerDTO? FindByIdDTO(int id)
    {
        var query = from owner in _context.Owners where owner.Id == id select owner;

        return query
            .Include(owner => owner.Pets!)
            .ThenInclude(pet => pet.PetType)
            .Select(
                owner =>
                    new OwnerDTO
                    {
                        Id = owner.Id,
                        FirstName = owner.FirstName,
                        LastName = owner.LastName,
                        Birthdate = owner.Birthdate,
                        Pets = owner.Pets!
                            .Select(
                                pet => new PetDTO { Name = pet.Name, PetType = pet.PetType.Name }
                            )
                            .ToList()
                    }
            )
            .FirstOrDefault();
    }

    public Owner? FindById(int id)
    {
        return _context.Owners.FirstOrDefault(owner => owner.Id == id);
    }

    public IEnumerable<OwnerDTO> FindByBirthdate(DateOnly birthdate)
    {
        var query = from owner in _context.Owners select owner;

        var owners = query
            .Where(owner => owner.Birthdate == birthdate)
            .Include(owner => owner.Pets!)
            .ThenInclude(pet => pet.PetType)
            .Select(
                owner =>
                    new OwnerDTO
                    {
                        Id = owner.Id,
                        FirstName = owner.FirstName,
                        LastName = owner.LastName,
                        Birthdate = owner.Birthdate,
                        Pets = owner.Pets!
                            .Select(
                                pet =>
                                    new PetDTO
                                    {
                                        Name = pet.Name,
                                        Birthdate = pet.Birthdate,
                                        PetType = pet.PetType.Name
                                    }
                            )
                            .ToList()
                    }
            );

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
                        Birthdate = owner.Birthdate,
                        Pets = owner.Pets!
                            .Select(
                                pet =>
                                    new PetDTO
                                    {
                                        Name = pet.Name,
                                        Birthdate = pet.Birthdate,
                                        PetType = pet.PetType.Name
                                    }
                            )
                            .ToList()
                    }
            );

        return owners;
    }
}
