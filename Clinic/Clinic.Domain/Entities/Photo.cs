namespace Clinic.Domain.Entities;

public class Photo
{
    public Guid Id { get; set; }
    public string Path { get; set; } 

    public Guid AccountId { get; set; }
}
