using MediatR;

namespace Clinic.Application.Commands.Receptionist.Create;

public record CreateReceptionistInput(
    string Email,
    string Password,
    string PhoneNumber,
    string FirstName,
    string LastName,
    string MiddleName,
    Guid OfficeId
) : IRequest<CreateReceptionistOutput>;
