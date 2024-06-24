using MediatR;

namespace Clinic.Application.Commands.Appointment.Create;

public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentInput, CreateAppointmentOutput>
{
    public Task<CreateAppointmentOutput> Handle(
        CreateAppointmentInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
