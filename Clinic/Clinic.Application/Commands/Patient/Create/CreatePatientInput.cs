using MediatR;

namespace Clinic.Application.Commands.Patient.Create;

public record CreatePatientInput(
    string FirstName,
    string LastName,
    string MiddleName,
    DateOnly DateOfBirth,
    Guid AccountId
) : IRequest<CreatePatientOutput>;
