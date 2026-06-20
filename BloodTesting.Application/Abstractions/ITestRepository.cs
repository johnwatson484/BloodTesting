using BloodTesting.Domain.Testing;

namespace BloodTesting.Application.Abstractions;

public interface ITestRepository
{
    Task<BloodTest?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(BloodTest bloodTest, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
