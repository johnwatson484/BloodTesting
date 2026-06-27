using BloodTesting.Domain;
using BloodTesting.Domain.Patients;
using BloodTesting.Domain.Testing;
using Microsoft.EntityFrameworkCore;

namespace BloodTesting.Adapters.EfSqlite.Persistence;

public sealed class BloodTestingDbContext(DbContextOptions<BloodTestingDbContext> options)
    : DbContext(options)
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<PatientRecord> PatientRecords => Set<PatientRecord>();
    public DbSet<BloodTest> BloodTests => Set<BloodTest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(builder =>
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.DateOfBirth).IsRequired();
        });

        modelBuilder.Entity<PatientRecord>(builder =>
        {
            builder.HasKey(r => r.Id);
            builder.HasOne(r => r.Patient)
                .WithOne()
                .HasForeignKey<PatientRecord>(r => r.Id);
            builder.HasMany(r => r.BloodTests)
                .WithOne()
                .HasForeignKey("PatientRecordId");
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

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        var patients = new[]
        {
            new Patient(Guid.Parse("11111111-1111-1111-1111-111111111111"), "John Doe", new DateTime(1980, 1, 1)),
            new Patient(Guid.Parse("22222222-2222-2222-2222-222222222222"), "Jane Smith", new DateTime(1990, 5, 15)),
            new Patient(Guid.Parse("33333333-3333-3333-3333-333333333333"), "Alice Johnson", new DateTime(1975, 10, 30)),
            new Patient(Guid.Parse("44444444-4444-4444-4444-444444444444"), "Bob Williams", new DateTime(1985, 3, 22)),
            new Patient(Guid.Parse("55555555-5555-5555-5555-555555555555"), "Carol Davis", new DateTime(1992, 7, 8)),
            new Patient(Guid.Parse("66666666-6666-6666-6666-666666666666"), "David Brown", new DateTime(1968, 11, 14)),
            new Patient(Guid.Parse("77777777-7777-7777-7777-777777777777"), "Emma Wilson", new DateTime(1995, 9, 2)),
            new Patient(Guid.Parse("88888888-8888-8888-8888-888888888888"), "Frank Miller", new DateTime(1972, 4, 19)),
            new Patient(Guid.Parse("99999999-9999-9999-9999-999999999999"), "Grace Taylor", new DateTime(1988, 12, 25)),
            new Patient(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Henry Anderson", new DateTime(1978, 6, 11)),
        };

        modelBuilder.Entity<Patient>().HasData(patients);

        modelBuilder.Entity<PatientRecord>().HasData(
            patients.Select(p => new { p.Id })
        );
    }
}
