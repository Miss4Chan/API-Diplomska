using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users {get;set;} 
    public DbSet<HeartRate> HeartRates { get; set; }
    public DbSet<SuddenMovement> SuddenMovements { get; set; }
    public DbSet<MedicationIntake> MedicationIntakes { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<HighHeartRate> HighHeartRates { get; set; }


    //Site ke idat one to many zatoa shto nema potreba od delenje na resursi megju useri 
    //nitu ima kopleksni strukturi
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // AppUser has many HeartRates (One-to-Many)
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.HeartRates)
            .WithOne(hr => hr.User)
            .HasForeignKey(hr => hr.UserId);

        // AppUser has many SuddenMovements (One-to-Many)
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.SuddenMovements)
            .WithOne(sm => sm.User)
            .HasForeignKey(sm => sm.UserId);

        // AppUser has many MedicationIntakes (One-to-Many)
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.MedicationIntakes)
            .WithOne(mi => mi.User)
            .HasForeignKey(mi => mi.UserId);

        // AppUser has many Medications (One-to-Many)
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.Medications)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);

        // AppUser has many HighHeartRates (One-to-Many)
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.HighHeartRates)
            .WithOne(hhr => hhr.User)
            .HasForeignKey(hhr => hhr.UserId);

        // Medication has many MedicationIntakes (One-to-Many)
        modelBuilder.Entity<Medication>()
            .HasMany(m => m.MedicationIntakes)
            .WithOne(mi => mi.Medication)
            .HasForeignKey(mi => mi.MedicationId);
    }
}
