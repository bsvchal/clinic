using Clinic.API.Models.Account;

namespace Clinic.API.Models.Doctor;

public class DoctorCreationRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public string Specialization { get; set; }
    public Guid OfficeId { get; set; }
}
