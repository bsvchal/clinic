using MediatR;

namespace Clinic.Application.Commands.Appointment.UpdateScheduledTime;

public record UpdateAppointmentScheduledTimeInput(
    Guid Id,
    DateTime ScheduledTime
) : IRequest;
