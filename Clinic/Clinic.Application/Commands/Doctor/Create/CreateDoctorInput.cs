using MediatR;

namespace Clinic.Application.Commands.Doctor.Create;

public record CreateDoctorInput(
    string Email,
    string Password,
    string PhoneNumber,
    string FirstName,
    string LastName,
    string MiddleName,
    DateOnly DateOfBirth,
    int CareerStartYear,
    string Specialization,
    Guid OfficeId
) : IRequest<CreateDoctorOutput>;
