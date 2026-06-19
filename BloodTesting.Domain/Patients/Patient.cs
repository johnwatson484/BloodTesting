namespace BloodTesting.Domain.Patients;

public sealed class Patient
{
    public Patient(int id, string name, DateTime dateOfBirth)
    {
        Id = id;
        Name = name;
        DateOfBirth = dateOfBirth;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }

    public int GetAge (DateTime currentDate)
    {
        int age = currentDate.Year - DateOfBirth.Year;
        if (currentDate < DateOfBirth.AddYears(age))
        {
            age--;
        }
        return age;
    }
}
