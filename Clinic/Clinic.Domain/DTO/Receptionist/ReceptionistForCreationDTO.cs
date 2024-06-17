using Clinic.Domain.DTO.Account;

namespace Clinic.Domain.DTO.Receptionist;

public class ReceptionistForCreationDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }   
    public string MiddleName { get; set; }
    public Guid OfficeId { get; set; }
    public AccountForCreationDTO AccountForCreation { get; set; }
}
