using MediatR;

namespace Clinic.Application.Queries.Appointment.GetById;

public record GetAppointmentByIdInput(Guid Id) : IRequest<GetAppointmentByIdOutput>;
