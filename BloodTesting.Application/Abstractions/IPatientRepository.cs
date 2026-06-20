using BloodTesting.Domain.Patients;

namespace BloodTesting.Application.Abstractions;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(Patient patient, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
