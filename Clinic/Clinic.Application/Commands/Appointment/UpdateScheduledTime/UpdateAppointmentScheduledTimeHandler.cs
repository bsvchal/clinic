using MediatR;

namespace Clinic.Application.Commands.Appointment.UpdateScheduledTime;

public class UpdateAppointmentScheduledTimeHandler
    : IRequestHandler<UpdateAppointmentScheduledTimeInput>
{
    public Task Handle(
        UpdateAppointmentScheduledTimeInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
