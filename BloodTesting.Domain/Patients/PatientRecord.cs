using BloodTesting.Domain.Testing;

namespace BloodTesting.Domain.Patients;

public sealed class PatientRecord
{
    public PatientRecord() {}

    public PatientRecord(Patient patient)
    {
        Id = patient.Id;
        Patient = patient;
    }

    public PatientRecord(Patient patient, List<BloodTest> bloodTests)
    {
        Id = patient.Id;
        Patient = patient;
        BloodTests = bloodTests;
    }

    public Guid Id { get; private set; }
    public Patient Patient { get; private set; }
    public List<BloodTest> BloodTests { get; private set; } = [];

    public void AddBloodTest(BloodTest bloodTest)
    {
        if(BloodTests.Any(b => b.Id == bloodTest.Id))
        {
            throw new InvalidOperationException("This blood test is already added to the patient record.");
        }

        BloodTests.Add(bloodTest);
    }
}
