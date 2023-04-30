using Microsoft.EntityFrameworkCore;
using Model.Entities.Airships;
using Model.Entities.Airships.Engines;
using Model.Entities.Airships.Weapons;

namespace Model.Configurations; 

public class SteamDbContext : DbContext {

    public DbSet<Airship> Airships { get; set; }
    public DbSet<AEngine> Engines { get; set; }
    public DbSet<Motorization> Motorizations { get; set; }
    public DbSet<Armory> Armories { get; set; }
    public DbSet<AWeapon> Weapons { get; set; }


    public SteamDbContext(DbContextOptions<SteamDbContext> options) : base(options) {
        
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Airship>()
            .HasIndex(a => a.Name)
            .IsUnique();
        builder.Entity<Airship>()
            .Property(a => a.DamageState)
            .HasConversion<string>();

        builder.Entity<AEngine>()
            .HasIndex(e => e.Label)
            .IsUnique();
        builder.Entity<AEngine>()
            .Property(e => e.PowerType)
            .HasConversion<string>();

        builder.Entity<AEngine>().HasDiscriminator<string>("ENGINE_TYPE")
            .HasValue<CombustionEngine>("COMBUSTION")
            .HasValue<SteamEngine>("STEAM")
            .HasValue<JetEngine>("JET");
        
        
        builder.Entity<Motorization>().HasKey(m => new {
            m.EngineId,
            m.AirshipId,
            m.Position
        });

        builder.Entity<Motorization>()
            .HasOne(m => m.Airship)
            .WithMany(a => a.MotorizationList)
            .HasForeignKey(m => m.AirshipId);
        
        builder.Entity<Motorization>()
            .HasOne(m => m.AEngine)
            .WithMany()
            .HasForeignKey(m => m.EngineId);

        builder.Entity<Motorization>()
            .Property(m => m.DamageState)
            .HasConversion<string>();

        
        
        
        builder.Entity<Armory>().HasKey(m => new {
            m.WeaponId,
            m.AirshipId,
            m.Position
        });
        builder.Entity<Armory>()
            .HasOne(m => m.Airship)
            .WithMany(a => a.ArmoryList)
            .HasForeignKey(m => m.AirshipId);

        builder.Entity<Armory>()
            .HasOne(m => m.Weapon)
            .WithMany()
            .HasForeignKey(m => m.WeaponId);

        builder.Entity<Armory>()
            .Property(m => m.DamageState)
            .HasConversion<string>();

        builder.Entity<AWeapon>()
            .HasDiscriminator<string>("WEAPON_TYPE")
            .HasValue<RapidFireWeapon>("RAPID_FIRE")
            .HasValue<Bomb>("BOMB")
            .HasValue<ProjectileWeapon>("PROJECTILE");

        builder.Entity<AWeapon>()
            .Property(w => w.Range)
            .HasConversion<string>();

    }
}
