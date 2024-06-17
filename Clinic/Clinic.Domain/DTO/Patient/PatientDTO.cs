using Clinic.Domain.DTO.Appointment;

namespace Clinic.Domain.DTO.Patient;

public class PatientDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
