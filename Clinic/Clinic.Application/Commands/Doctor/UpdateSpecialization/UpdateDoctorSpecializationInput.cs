using MediatR;

namespace Clinic.Application.Commands.Doctor.UpdateSpecialization;

public record UpdateDoctorSpecializationInput(
    Guid Id,
    string Specialization
) : IRequest;
