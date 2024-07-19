using System.ComponentModel.DataAnnotations;

namespace Clinic.Domain.Entities;

public class Office : BaseEntity
{
    [MaxLength(30)]
    public string CityName { get; set; }
    [MaxLength(15)]
    public string RegistryPhoneNumber { get; set; } 
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Receptionist> Receptionists { get; set; }
}
