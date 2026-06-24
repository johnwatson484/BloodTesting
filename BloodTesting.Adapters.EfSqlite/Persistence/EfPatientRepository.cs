using BloodTesting.Application.Abstractions;
using BloodTesting.Domain.Patients;
using Microsoft.EntityFrameworkCore;

namespace BloodTesting.Adapters.EfSqlite.Persistence;

public sealed class EfPatientRepository(BloodTestingDbContext db) : IPatientRepository
{
    public async Task AddAsync(Patient patient, CancellationToken cancellationToken)
    {
        await db.Patients.AddAsync(patient, cancellationToken);
    }

    public async Task<Patient?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await db.Patients.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await db.SaveChangesAsync(cancellationToken);
    }
}
