using Clinic.Domain.DTO.Account;

namespace Clinic.Domain.DTO.Doctor;

public class DoctorForCreationDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; } 
    public DateOnly DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public string Specialization { get; set; }
    public Guid OfficeId { get; set; }
    public AccountForCreationDTO AccountForCreation { get; set; }
}
