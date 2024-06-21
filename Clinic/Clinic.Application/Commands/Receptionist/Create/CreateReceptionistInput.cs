using MediatR;

namespace Clinic.Application.Commands.Receptionist.Create;

public record CreateReceptionistInput(
    string FirstName,
    string LastName,
    string MiddleName,
    Guid AccountId,
    Guid OfficeId
) : IRequest<CreateReceptionistOutput>;
