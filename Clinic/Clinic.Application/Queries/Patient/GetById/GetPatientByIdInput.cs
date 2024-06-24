using MediatR;

namespace Clinic.Application.Queries.Patient.GetById;

public record GetPatientByIdInput(Guid Id) : IRequest<GetPatientByIdOutput>;
