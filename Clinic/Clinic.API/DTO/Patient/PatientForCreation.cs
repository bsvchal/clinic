using Clinic.API.DTO.Account;

namespace Clinic.API.DTO.Patient;

public class PatientForCreation
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public AccountForCreation AccountForCreation { get; set; }
}
