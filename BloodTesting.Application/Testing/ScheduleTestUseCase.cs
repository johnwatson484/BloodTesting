using BloodTesting.Application.Abstractions;
using BloodTesting.Domain.Testing;

namespace BloodTesting.Application.Testing;

public sealed record ScheduleTestCommand(
    Guid PatientId,
    TestType TestType,
    TestPriority Priority
);

public sealed class ScheduleTestUseCase
{
    public async Task<TestDetailsDto> ExecuteAsync(ScheduleTestCommand command, IPatientRepository patientRepository, ITestRepository testRepository, IProcessingQueue processingQueue, CancellationToken cancellationToken)
    {
        var patient = await patientRepository.GetByIdAsync(command.PatientId, cancellationToken)
            ?? throw new ArgumentException($"Patient with ID {command.PatientId} not found.");

        var bloodTest = new BloodTest(
            Guid.NewGuid(),
            patient,
            DateTime.UtcNow,
            command.TestType,
            command.Priority
            );

        await testRepository.AddAsync(bloodTest, cancellationToken);
        await testRepository.SaveChangesAsync(cancellationToken);

        await processingQueue.Enqueue(bloodTest);

        return new TestDetailsDto(
            bloodTest.Id,
            bloodTest.Patient.Id,
            bloodTest.Type,
            bloodTest.Priority,
            bloodTest.TestDate
        );
        }
}
