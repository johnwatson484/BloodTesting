using BloodTesting.Domain;
using BloodTesting.Domain.Patients;
using BloodTesting.Domain.Testing;
using Microsoft.EntityFrameworkCore;

namespace BloodTesting.Adapters.EfSqlite.Persistence;

public sealed class BloodTestingDbContext(DbContextOptions<BloodTestingDbContext> options)
    : DbContext(options)
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<BloodTest> BloodTests => Set<BloodTest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(builder =>
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.DateOfBirth).IsRequired();
        });

        modelBuilder.Entity<BloodTest>(builder =>
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TestDate).IsRequired();
            builder.Property(t => t.Type).IsRequired();
            builder.Property(t => t.Priority).IsRequired();
            builder.Property(t => t.Status).IsRequired();
            builder.Property(t => t.Result);
            builder.HasOne(t => t.Patient);
        });
    }
}
