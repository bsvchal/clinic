namespace Clinic.API.Models.Appointment;

public class AppointmentForCreation
{
    public DateTime ScheduledFor { get; set; }
    public decimal Price { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
}
