using MediatR;

namespace Clinic.Application.Commands.Receptionist.Delete;

public record DeleteReceptionistInput(
    Guid Id) : IRequest;
