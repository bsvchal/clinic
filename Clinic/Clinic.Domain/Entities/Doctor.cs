namespace Clinic.Domain.Entities;

public class Doctor
{

    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public bool IsWorking { get; set; }
    public string Specialization { get; set; } = string.Empty;
    public Guid OfficeId { get; set; }
    public Office Office { get; set; } = null!;
    public Guid AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public IEnumerable<Appointment> Appointments { get; set; } = [];
}
