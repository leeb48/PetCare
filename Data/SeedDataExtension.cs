using PetCare.Modules.OwnerModule;
using PetCare.Modules.PetModule;

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

        var owners = new Owner[]
        {
            new()
            {
                FirstName = "Megan",
                LastName = "Wu",
                Address = "1212 Beautify St",
                State = "NV",
                PhoneNumber = "1231231234",
                Email = "lovely@test.com",
                Pets = new List<Pet>()
                {
                    new() { Name = "Acorn", Birthdate = new DateTime(2020, 4, 10) }
                }
            },
            new()
            {
                FirstName = "Bong",
                LastName = "Lee",
                Address = "3232 Nerd Ave",
                State = "NV",
                PhoneNumber = "3213214321",
                Email = "bongster@test.com",
                Pets = new List<Pet>()
                {
                    new() { Name = "Mango", Birthdate = new DateTime(2019, 5, 10) }
                }
            },
            new()
            {
                FirstName = "Mango",
                LastName = "Lee",
                Address = "4848 Golden Dr",
                State = "NV",
                PhoneNumber = "1295432323",
                Email = "mango@test.com"
            },
            new()
            {
                FirstName = "Acorn",
                LastName = "Wu",
                Address = "4959 Corgi St",
                State = "NV",
                PhoneNumber = "4051231232",
                Email = "acorn@test.com"
            },
        };

        context.Owners.AddRange(owners);
        context.SaveChanges();
    }
}
