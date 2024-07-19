using MediatR;

namespace Clinic.Application.Commands.Appointment.Approve;

public record ApproveAppointmentInput(Guid Id) : IRequest;
