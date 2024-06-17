namespace Clinic.Domain.DTO.Appointment;

public class AppointmentForCreationDTO
{
    public DateTime ScheduledFor { get; set; }
    public decimal Price { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
}
