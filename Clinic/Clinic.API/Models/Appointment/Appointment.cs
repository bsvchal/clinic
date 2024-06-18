namespace Clinic.API.Models.Appointment;

public class Appointment
{
    public DateTime ScheduledFor { get; set; }
    public bool IsApproved { get; set; }
    public decimal Price { get; set; }
}
