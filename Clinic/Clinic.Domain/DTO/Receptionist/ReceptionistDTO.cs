namespace Clinic.Domain.DTO.Receptionist;

public class ReceptionistDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string MiddleName { get; set; } 
    public Guid OfficeId { get; set; }
}
