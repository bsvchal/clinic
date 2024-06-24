using MediatR;

namespace Clinic.Application.Commands.Office.Create;

public record CreateOfficeInput(
    string CityName,
    string RegistryPhoneNumber
) : IRequest<CreateOfficeOutput>;
