namespace BloodTesting.Domain;

public class BloodTest
{
    public BloodTest(int id, Patient patient, DateTime testDate, TestType testType, TestPriority testPriority)
    {
        Id = id;
        Patient = patient;
        TestDate = testDate;
        Type = testType;
        Priority = testPriority;
    }

    public int Id { get; private set; }
    public Patient Patient { get; private set; }
    public DateTime TestDate { get; private set; }
    public TestType Type { get; private set; }
    public TestPriority Priority { get; private set; }
    public TestResult? Result { get; private set; } = null;

    public void SetResult(TestResult result)
    {
        Result = result;
    }
}
