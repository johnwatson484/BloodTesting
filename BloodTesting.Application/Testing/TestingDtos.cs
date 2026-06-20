using BloodTesting.Domain.Testing;

namespace BloodTesting.Application.Testing;

public sealed record TestDetailsDto(
    Guid TestId,
    Guid PatientId,
    TestType TestType,
    TestPriority Priority,
    DateTime TestDate
);
