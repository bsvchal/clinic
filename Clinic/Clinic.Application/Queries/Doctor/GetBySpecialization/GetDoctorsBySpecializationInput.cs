using MediatR;

namespace Clinic.Application.Queries.Doctor.GetBySpecialization;

public record GetDoctorsBySpecializationInput(
    string Specialization) : IRequest<GetDoctorsBySpecializationOutput>;
