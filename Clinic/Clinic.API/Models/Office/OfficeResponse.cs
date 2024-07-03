using Clinic.API.Models.Doctor;

namespace Clinic.API.Models.Office;

public class OfficeResponse
{
    public Guid Id { get; set; }
    public string CityName { get; set; }
    public string RegistryPhoneNumber { get; set; }

    public OfficeResponse(Domain.Entities.Office office)
    {
        Id = office.Id;
        CityName = office.CityName;
        RegistryPhoneNumber = office.RegistryPhoneNumber;
    }
}
