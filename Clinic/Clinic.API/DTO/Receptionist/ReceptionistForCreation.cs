using Clinic.API.DTO.Account;

namespace Clinic.API.DTO.Receptionist;

public class ReceptionistForCreation
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Guid OfficeId { get; set; }
    public AccountForCreation AccountForCreation { get; set; }
}
