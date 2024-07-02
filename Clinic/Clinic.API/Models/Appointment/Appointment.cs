namespace Clinic.API.Models.Appointment;

public class Appointment
{
    public DateTime ScheduledTime { get; set; }
    public bool IsApproved { get; set; }
    public decimal Price { get; set; }
    public Doctor.Doctor Doctor { get; set; }
    public Patient.Patient Patient { get; set; }

    public Appointment(Domain.Entities.Appointment appointment)
    {
        ScheduledTime = appointment.ScheduledTime;
        IsApproved = appointment.IsApproved;
        Price = appointment.Price;
        Patient = new Patient.Patient
        {
            FirstName = appointment.Patient.FirstName,
            LastName = appointment.Patient.LastName,
            MiddleName = appointment.Patient.MiddleName,
            DateOfBirth = appointment.Patient.DateOfBirth
        };
        Doctor = new Doctor.Doctor
        {
            FirstName = appointment.Doctor.FirstName,
            LastName = appointment.Doctor.LastName,
            MiddleName = appointment.Doctor.MiddleName,
            DateOfBirth = appointment.Doctor.DateOfBirth,
            CareerStartYear = appointment.Doctor.CareerStartYear,
            IsWorking = appointment.Doctor.IsWorking,
            Specialization = appointment.Doctor.Specialization
        };
    }
}
