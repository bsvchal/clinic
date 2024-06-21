using MediatR;

namespace Clinic.Application.Queries.Receptionist.GetById;

public record GetReceptionistByIdInput(Guid Id) : IRequest<GetReceptionistByIdOutput>;
