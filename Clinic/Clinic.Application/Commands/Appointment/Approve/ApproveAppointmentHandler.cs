using MediatR;

namespace Clinic.Application.Commands.Appointment.Approve;

public class ApproveAppointmentHandler
    : IRequestHandler<ApproveAppointmentInput>
{
    public Task Handle(
        ApproveAppointmentInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
