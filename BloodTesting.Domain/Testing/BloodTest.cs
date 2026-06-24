using BloodTesting.Domain.Patients;

namespace BloodTesting.Domain.Testing;

public sealed class BloodTest
{
    public BloodTest() {}

    public BloodTest(Guid id, Patient patient, DateTime testDate, TestType testType, TestPriority testPriority)
    {
        Id = id;
        Patient = patient;
        TestDate = testDate;
        Type = testType;
        Priority = testPriority;
    }

    public Guid Id { get; private set; }
    public Patient Patient { get; private set; }
    public DateTime TestDate { get; private set; }
    public TestType Type { get; private set; }
    public TestPriority Priority { get; private set; }
    public TestStatus Status { get; private set; } = TestStatus.Pending;
    public TestResult? Result { get; private set; } = null;

    public void SetStatus(TestStatus status)
    {
        Status = status;
    }

    public void SetResult(TestResult result)
    {
        Result = result;
    }
}
