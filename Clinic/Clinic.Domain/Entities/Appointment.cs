using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public DateTime ScheduledTime { get; set; }
    public bool IsApproved { get; set; }
    [Precision(10, 3)]
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } 
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; } 
}
