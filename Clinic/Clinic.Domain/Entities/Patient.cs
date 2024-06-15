namespace Clinic.Domain.Entities;

public class Patient
{

    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public Guid AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public IEnumerable<Appointment> Appointments { get; set; } = [];
}
