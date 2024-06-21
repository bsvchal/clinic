using MediatR;

namespace Clinic.Application.Queries.Doctor.GetByOffice;

public record GetDoctorsByOfficeInput(Guid OfficeId) : IRequest<GetDoctorsByOfficeOutput>;
