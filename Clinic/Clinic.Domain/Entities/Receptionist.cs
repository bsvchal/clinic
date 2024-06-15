namespace Clinic.Domain.Entities;

public class Receptionist
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public Guid AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public Guid OfficeId { get; set; }
    public Office Office { get; set; } = null!;
}
