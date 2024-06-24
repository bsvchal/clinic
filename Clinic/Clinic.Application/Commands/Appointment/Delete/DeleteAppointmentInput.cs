using MediatR;

namespace Clinic.Application.Commands.Appointment.Delete;

public record DeleteAppointmentInput(Guid Id) : IRequest;
