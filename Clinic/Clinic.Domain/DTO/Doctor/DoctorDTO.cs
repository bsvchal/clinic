using Clinic.Domain.DTO.Appointment;

namespace Clinic.Domain.DTO.Doctor;

public class DoctorDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public bool IsWorking { get; set; }
    public string Specialization { get; set; }
}
