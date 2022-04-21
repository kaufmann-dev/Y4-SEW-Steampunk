using Microsoft.EntityFrameworkCore;
using Model.Entities.Airships;
using Model.Entities.Airships.Engines;
using Model.Entities.Airships.Weapons;

namespace Model.Configurations; 

public class SteamDbContext : DbContext {

    public DbSet<Airship> Airships { get; set; }
    public DbSet<Engine> Engines { get; set; }
    public DbSet<Motorization> Motorizations { get; set; }
    
    
    public SteamDbContext(DbContextOptions<SteamDbContext> options) : base(options) {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Airship>().HasIndex(a=>a.Name).IsUnique();
        builder.Entity<Airship>().Property(a => a.DamageState).HasConversion<string>();
        
        builder.Entity<Engine>().HasIndex(e => e.Label).IsUnique();
        builder.Entity<Engine>().Property(e => e.PowerType).HasConversion<string>();
        builder.Entity<Engine>()
            .HasDiscriminator<string>("ENGINE_TYPE")
            .HasValue<CombustionEngine>("COMBUSTION")
            .HasValue<SteamEngine>("STEAM")
            .HasValue<JetEngine>("JET");

        builder.Entity<Motorization>().HasKey(m => new
        {
            m.EngineId,
            m.AirshipId
        });

        builder.Entity<Motorization>()
            .HasOne(m => m.Airship)
            .WithMany()
            .HasForeignKey(m => m.AirshipId);
        
        builder.Entity<Motorization>()
            .HasOne(m => m.Engine)
            .WithMany()
            .HasForeignKey(m => m.EngineId);
    }
}
