namespace Clinic.API.Models.Appointment;

public class AppointmentCreationRequest
{
    public DateTime ScheduledTime { get; set; }
    public decimal Price { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
}
