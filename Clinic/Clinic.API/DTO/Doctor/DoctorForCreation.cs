using Clinic.API.DTO.Account;

namespace Clinic.API.DTO.Doctor;

public class DoctorForCreation
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public string Specialization { get; set; }
    public Guid OfficeId { get; set; }
    public AccountForCreation AccountForCreation { get; set; }
}
