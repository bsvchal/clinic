using Clinic.API.Models.Appointment;

namespace Clinic.API.Models.Doctor;

public class Doctor
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public bool IsWorking { get; set; }
    public string Specialization { get; set; }
}
