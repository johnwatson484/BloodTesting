using BloodTesting.Application.Abstractions;
using BloodTesting.Domain.Testing;
using Microsoft.EntityFrameworkCore;

namespace BloodTesting.Adapters.EfSqlite.Persistence;

public sealed class EfTestRepository(BloodTestingDbContext db) : ITestRepository
{
    public async Task AddAsync(BloodTest test, CancellationToken cancellationToken)
    {
        await db.BloodTests.AddAsync(test, cancellationToken);
    }

    public async Task<BloodTest?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await db.BloodTests.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await db.SaveChangesAsync(cancellationToken);
    }
}
