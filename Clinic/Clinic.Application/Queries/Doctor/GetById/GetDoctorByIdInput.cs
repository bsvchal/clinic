using MediatR;

namespace Clinic.Application.Queries.Doctor.GetById;

public record GetDoctorByIdInput(Guid Id) : IRequest<GetDoctorByIdOutput>;
