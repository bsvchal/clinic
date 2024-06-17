namespace Clinic.Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public DateTime ScheduledFor { get; set; }
    public bool IsApproved { get; set; } 
    public decimal Price { get; set; } 

    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } 
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; } 
}
