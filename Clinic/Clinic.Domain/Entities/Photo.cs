namespace Clinic.Domain.Entities;

public class Photo : BaseEntity
{
    public string Path { get; set; } 
    public Guid AccountId { get; set; }
}
