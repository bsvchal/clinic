namespace Clinic.Domain.Entities;

public class Office
{
    public Guid Id { get; set; }
    public string CityName { get; set; } 
    public string RegistryPhoneNumber { get; set; } 
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Receptionist> Receptionists { get; set; }
}
