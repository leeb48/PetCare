using Microsoft.EntityFrameworkCore;
using PetCare.Modules.OwnerModule;
using PetCare.Modules.PetModule;

namespace PetCare.Data;

public class PetCareContext : DbContext
{
    public PetCareContext(DbContextOptions<PetCareContext> options)
        : base(options) { }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<PetType> PetTypes { get; set; }
}
