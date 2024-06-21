namespace Clinic.Application.Queries.Office.GetByCity;

public record GetOfficesByCityOutput(
    IEnumerable<Domain.Entities.Office> Offices);
