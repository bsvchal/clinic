namespace Clinic.API.Models.Patient;

public class PatientResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public PatientResponse(Domain.Entities.Patient patient)
    {
        Id = patient.Id;
        FirstName = patient.FirstName;
        LastName = patient.LastName;
        MiddleName = patient.MiddleName;
        DateOfBirth = patient.DateOfBirth;
    }
}
