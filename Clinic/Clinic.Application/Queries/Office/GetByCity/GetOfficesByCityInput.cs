using MediatR;

namespace Clinic.Application.Queries.Office.GetByCity;

public record GetOfficesByCityInput(string CityName) : IRequest<GetOfficesByCityOutput>;
