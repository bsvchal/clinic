using System.ComponentModel.DataAnnotations;

namespace Clinic.Domain.Entities;

public class Receptionist : BaseEntity
{
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [MaxLength(30)]
    public string MiddleName { get; set; }
    public Guid AccountId { get; set; }
    public Guid OfficeId { get; set; }
    public Office Office { get; set; } 
}
