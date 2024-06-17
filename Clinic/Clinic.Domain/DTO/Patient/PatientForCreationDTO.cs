using Clinic.Domain.DTO.Account;

namespace Clinic.Domain.DTO.Patient;

public class PatientForCreationDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public AccountForCreationDTO AccountForCreation { get; set; }
}
