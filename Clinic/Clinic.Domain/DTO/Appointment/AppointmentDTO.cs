namespace Clinic.Domain.DTO.Appointment;

public class AppointmentDTO
{
    public DateTime ScheduledFor { get; set; }
    public bool IsApproved { get; set; }
    public decimal Price { get; set; }
}
