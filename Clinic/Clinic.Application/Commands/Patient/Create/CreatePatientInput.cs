using MediatR;

namespace Clinic.Application.Commands.Patient.Create;

public record CreatePatientInput(
    string Email,
    string Password,
    string PhoneNumber,
    string FirstName,
    string LastName,
    string MiddleName,
    DateOnly DateOfBirth
) : IRequest<CreatePatientOutput>;
