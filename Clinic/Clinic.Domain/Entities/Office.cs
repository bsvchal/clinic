namespace Clinic.Domain.Entities;

public class Office
{
    public Guid Id { get; set; }
    public string City { get; set; } 
    public string RegistryPhoneNumber { get; set; } 

    public IEnumerable<Doctor> Doctors { get; set; }
    public IEnumerable<Receptionist> Receptionists { get; set; }
}
