using System.ComponentModel.DataAnnotations;

namespace Clinic.Domain.Entities;

public class Patient : BaseEntity
{
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [MaxLength(30)]
    public string MiddleName { get; set; } 
    public DateOnly DateOfBirth { get; set; }
    public Guid AccountId { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}
