namespace Clinic.Domain.Entities;

public class Doctor
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public bool IsWorking { get; set; }
    public string Specialization { get; set; } 

    public Guid OfficeId { get; set; }
    public Office Office { get; set; } 
    public Guid AccountId { get; set; }
    public Account Account { get; set; } 
    public IEnumerable<Appointment> Appointments { get; set; }
}
