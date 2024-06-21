using MediatR;

namespace Clinic.Application.Commands.Appointment.Delete;

public class DeleteAppointmentHandler
    : IRequestHandler<DeleteAppointmentInput>
{
    public Task Handle(
        DeleteAppointmentInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
