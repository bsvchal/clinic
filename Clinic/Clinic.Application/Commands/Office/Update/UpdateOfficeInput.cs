using MediatR;

namespace Clinic.Application.Commands.Office.Update;

public record UpdateOfficeInput(
    Guid Id,
    string RegistryPhoneNumber
) : IRequest;
