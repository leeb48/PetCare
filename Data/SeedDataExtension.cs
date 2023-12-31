using PetCare.Modules.OwnerModule;
using PetCare.Modules.PetModule;
using SQLitePCL;

namespace PetCare.Data;

public static class SeedDataExtension
{
    public static void SeedData(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<PetCareContext>();

        context.Database.EnsureCreated();

        if (context.Owners.Any() && context.Pets.Any())
            return;

        var dog = new PetType() { Name = "Dog" };
        var cat = new PetType() { Name = "Cat" };
        var other = new PetType() { Name = "Other" };

        var petTypes = new PetType[] { dog, cat, other };

        var owners = new Owner[]
        {
            new()
            {
                FirstName = "Megan",
                LastName = "Wu",
                Address = "1212 Beautify St",
                City = "Las Vegas",
                State = "NV",
                PhoneNumber = "1231231234",
                Email = "lovely@test.com",
                Pets = new List<Pet>()
                {
                    new()
                    {
                        Name = "Acorn",
                        Birthdate = new DateOnly(2020, 4, 10),
                        PetType = dog
                    }
                },
                Birthdate = new DateOnly(1996, 05, 31),
            },
            new()
            {
                FirstName = "Bong",
                LastName = "Lee",
                Address = "3232 Nerd Ave",
                City = "Las Vegas",
                State = "NV",
                PhoneNumber = "3213214321",
                Email = "bongster@test.com",
                Pets = new List<Pet>()
                {
                    new()
                    {
                        Name = "Mango",
                        Birthdate = new DateOnly(2019, 5, 10),
                        PetType = dog
                    }
                },
                Birthdate = new DateOnly(1991, 03, 14),
            },
            new()
            {
                FirstName = "Mango",
                LastName = "Lee",
                Address = "4848 Golden Dr",
                City = "Las Vegas",
                State = "NV",
                PhoneNumber = "1295432323",
                Email = "mango@test.com",
                Birthdate = new DateOnly(1996, 05, 31),
            },
            new()
            {
                FirstName = "Acorn",
                LastName = "Wu",
                Address = "4959 Corgi St",
                City = "Las Vegas",
                State = "NV",
                PhoneNumber = "4051231232",
                Email = "acorn@test.com",
                Birthdate = new DateOnly(1996, 05, 31),
            },
        };

        context.PetTypes.AddRange(petTypes);
        context.Owners.AddRange(owners);
        context.SaveChanges();
    }
}
