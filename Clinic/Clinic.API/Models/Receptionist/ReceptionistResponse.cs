namespace Clinic.API.Models.Receptionist;

public class ReceptionistResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public ReceptionistResponse(Domain.Entities.Receptionist receptionist)
    {
        Id = receptionist.Id;
        FirstName = receptionist.FirstName;
        LastName = receptionist.LastName;
        MiddleName = receptionist.MiddleName;
    }
}
