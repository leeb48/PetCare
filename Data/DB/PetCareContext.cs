using Microsoft.EntityFrameworkCore;
using PetCare.Modules.Owner;

namespace PetCare.Data;

public class PetCareContext : DbContext
{
    public PetCareContext(DbContextOptions<PetCareContext> options)
        : base(options) { }

    public DbSet<Owner> Owners { get; set; }
}
