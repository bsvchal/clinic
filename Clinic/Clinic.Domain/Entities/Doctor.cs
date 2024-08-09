using System.ComponentModel.DataAnnotations;

namespace Clinic.Domain.Entities;

public class Doctor : BaseEntity
{
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [MaxLength(30)]
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public bool IsWorking { get; set; }
    [MaxLength(30)]
    public string Specialization { get; set; } 
    public Guid? OfficeId { get; set; }
    public Office? Office { get; set; } 
    public Guid AccountId { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}
