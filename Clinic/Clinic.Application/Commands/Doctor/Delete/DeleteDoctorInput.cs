using MediatR;

namespace Clinic.Application.Commands.Doctor.Delete;

public record DeleteDoctorInput(Guid Id) : IRequest;
