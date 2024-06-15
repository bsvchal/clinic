namespace Clinic.Domain.Entities;

public class Office
{
    public Guid Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string RegistryPhoneNumber { get; set; } = string.Empty;
    public IEnumerable<Doctor> Doctors { get; set; } = [];
    public IEnumerable<Receptionist> Receptionists { get; set; } = [];
}
