using Clinic.API.Models.Appointment;

namespace Clinic.API.Models.Patient;

public class Patient
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
