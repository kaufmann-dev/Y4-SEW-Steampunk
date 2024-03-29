﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configurations;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(SteamDbContext))]
    partial class SteamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entities.Airships.Airship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AIRSHIP_ID");

                    b.Property<int>("ArmorValue")
                        .HasColumnType("int")
                        .HasColumnName("ARMOR_VALUE");

                    b.Property<string>("DamageState")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DAMAGE_STATE");

                    b.Property<int>("HullPoints")
                        .HasColumnType("int")
                        .HasColumnName("HULL_POINTS");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.Property<int>("Speed")
                        .HasColumnType("int")
                        .HasColumnName("AIRSHIP_SPEED");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AIRSHIPS");
                });

            modelBuilder.Entity("Model.Entities.Airships.Engines.AEngine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ENGINE_ID");

                    b.Property<string>("ENGINE_TYPE")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ENGINE_LABEL");

                    b.Property<string>("PowerType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("POWER_TYPE");

                    b.HasKey("Id");

                    b.HasIndex("Label")
                        .IsUnique();

                    b.ToTable("ENGINES_ST");

                    b.HasDiscriminator<string>("ENGINE_TYPE").HasValue("AEngine");
                });

            modelBuilder.Entity("Model.Entities.Airships.Engines.Motorization", b =>
                {
                    b.Property<int>("EngineId")
                        .HasColumnType("int")
                        .HasColumnName("ENGINE_ID");

                    b.Property<int>("AirshipId")
                        .HasColumnType("int")
                        .HasColumnName("AIRSHIP_ID");

                    b.Property<int>("Position")
                        .HasColumnType("int")
                        .HasColumnName("POSITION");

                    b.Property<string>("DamageState")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("DAMAGE_STATE");

                    b.HasKey("EngineId", "AirshipId", "Position");

                    b.HasIndex("AirshipId");

                    b.ToTable("AIRSHIP_HAS_ENGINES_JT");
                });

            modelBuilder.Entity("Model.Entities.Airships.Weapons.Armory", b =>
                {
                    b.Property<int>("WeaponId")
                        .HasColumnType("int")
                        .HasColumnName("WEAPON_ID");

                    b.Property<int>("AirshipId")
                        .HasColumnType("int")
                        .HasColumnName("SHIP_ID");

                    b.Property<int>("Position")
                        .HasColumnType("int")
                        .HasColumnName("POSITION");

                    b.Property<string>("DamageState")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("DAMAGE_STATE");

                    b.HasKey("WeaponId", "AirshipId", "Position");

                    b.HasIndex("AirshipId");

                    b.ToTable("SHIP_HAS_WEAPONS_JT");
                });

            modelBuilder.Entity("Model.Entities.Airships.Weapons.AWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WEAPON_ID");

                    b.Property<int>("AmmonitionCapacity")
                        .HasColumnType("int")
                        .HasColumnName("AMMONITION_CAPACITY");

                    b.Property<int>("AttackValue")
                        .HasColumnType("int")
                        .HasColumnName("ATTACK_VALUE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.Property<string>("Range")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("RANGE");

                    b.Property<string>("WEAPON_TYPE")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("WEAPONS_ST");

                    b.HasDiscriminator<string>("WEAPON_TYPE").HasValue("AWeapon");
                });

            modelBuilder.Entity("Model.Entities.Airships.Engines.CombustionEngine", b =>
                {
                    b.HasBaseType("Model.Entities.Airships.Engines.AEngine");

                    b.ToTable("ENGINES_ST");

                    b.HasDiscriminator().HasValue("COMBUSTION");
                });

            modelBuilder.Entity("Model.Entities.Airships.Engines.JetEngine", b =>
                {
                    b.HasBaseType("Model.Entities.Airships.Engines.AEngine");

                    b.ToTable("ENGINES_ST");

                    b.HasDiscriminator().HasValue("JET");
                });

            modelBuilder.Entity("Model.Entities.Airships.Engines.SteamEngine", b =>
                {
                    b.HasBaseType("Model.Entities.Airships.Engines.AEngine");

                    b.ToTable("ENGINES_ST");

                    b.HasDiscriminator().HasValue("STEAM");
                });

            modelBuilder.Entity("Model.Entities.Airships.Weapons.Bomb", b =>
                {
                    b.HasBaseType("Model.Entities.Airships.Weapons.AWeapon");

                    b.ToTable("WEAPONS_ST");

                    b.HasDiscriminator().HasValue("BOMB");
                });

            modelBuilder.Entity("Model.Entities.Airships.Weapons.ProjectileWeapon", b =>
                {
                    b.HasBaseType("Model.Entities.Airships.Weapons.AWeapon");

                    b.ToTable("WEAPONS_ST");

                    b.HasDiscriminator().HasValue("PROJECTILE");
                });

            modelBuilder.Entity("Model.Entities.Airships.Weapons.RapidFireWeapon", b =>
                {
                    b.HasBaseType("Model.Entities.Airships.Weapons.AWeapon");

                    b.ToTable("WEAPONS_ST");

                    b.HasDiscriminator().HasValue("RAPID_FIRE");
                });

            modelBuilder.Entity("Model.Entities.Airships.Engines.Motorization", b =>
                {
                    b.HasOne("Model.Entities.Airships.Airship", "Airship")
                        .WithMany("MotorizationList")
                        .HasForeignKey("AirshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Airships.Engines.AEngine", "AEngine")
                        .WithMany()
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AEngine");

                    b.Navigation("Airship");
                });

            modelBuilder.Entity("Model.Entities.Airships.Weapons.Armory", b =>
                {
                    b.HasOne("Model.Entities.Airships.Airship", "Airship")
                        .WithMany("ArmoryList")
                        .HasForeignKey("AirshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Airships.Weapons.AWeapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airship");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("Model.Entities.Airships.Airship", b =>
                {
                    b.Navigation("ArmoryList");

                    b.Navigation("MotorizationList");
                });
#pragma warning restore 612, 618
        }
    }
}
