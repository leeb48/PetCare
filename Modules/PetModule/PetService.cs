using PetCare.Data;
using PetCare.Modules.PetModule.DTO;

namespace PetCare.Modules.PetModule;

public class PetService : IPetService
{
    private readonly PetCareContext _context;

    public PetService(PetCareContext context)
    {
        _context = context;
    }

    private PetType GetPetType(string petTypeName)
    {
        var petType = _context.PetTypes.FirstOrDefault(
            pt => pt.Name.ToUpper() == petTypeName.ToUpper()
        );

        if (petType == null)
        {
            petType = new PetType { Name = petTypeName };
            _context.PetTypes.Add(petType);
            _context.SaveChanges();
        }

        return petType;
    }

    public Pet CreatePet(int ownerId, PetDTO petDTO)
    {
        var petType = GetPetType(petDTO.PetTypeName!);

        var newPet = new Pet
        {
            Name = petDTO.Name!,
            Birthdate = petDTO.Birthdate,
            PetType = petType,
            OwnerId = ownerId
        };

        _context.Pets.Add(newPet);

        _context.SaveChanges();

        return newPet;
    }

    public void RemovePet(int ownerId, int petId)
    {
        var pet =
            _context.Pets.Where(pet => pet.Id == petId).FirstOrDefault()
            ?? throw new Exception($"Pet with ID: {petId} not found");

        if (pet.OwnerId != ownerId)
        {
            throw new Exception("Pet does not belong to the owner");
        }

        _context.Pets.Remove(pet);
        _context.SaveChanges();
    }
}
