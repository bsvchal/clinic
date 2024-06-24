using MediatR;

namespace Clinic.Application.Queries.Office.GetById;

public record GetOfficeByIdInput(Guid Id) : IRequest<GetOfficeByIdOutput>;
