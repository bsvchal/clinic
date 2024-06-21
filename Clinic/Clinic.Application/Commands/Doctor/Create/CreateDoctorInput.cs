using MediatR;

namespace Clinic.Application.Commands.Doctor.Create;

public record CreateDoctorInput(
    string FirstName,
    string LastName,
    string MiddleName,
    DateOnly DateOfBirth,
    int CareerStartYear,
    string Specialization,
    Guid OfficeId,
    Guid AccountId
) : IRequest<CreateDoctorOutput>;
