using MediatR;

namespace Clinic.Application.Commands.Patient.Delete;

public record DeletePatientInput(Guid Id) : IRequest;
