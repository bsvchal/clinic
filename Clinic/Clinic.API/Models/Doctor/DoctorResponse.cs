using Clinic.API.Models.Appointment;

namespace Clinic.API.Models.Doctor;

public class DoctorResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public bool IsWorking { get; set; }
    public string Specialization { get; set; }
    public string? OfficeCityName { get; set; }

    public DoctorResponse(Domain.Entities.Doctor doctor)
    {
        Id = doctor.Id;
        FirstName = doctor.FirstName;
        LastName = doctor.LastName;
        MiddleName = doctor.MiddleName;
        DateOfBirth = doctor.DateOfBirth;
        CareerStartYear = doctor.CareerStartYear;
        IsWorking = doctor.IsWorking;
        Specialization = doctor.Specialization;
        OfficeCityName = doctor.Office?.CityName;
    }
}
