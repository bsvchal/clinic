using MediatR;

namespace Clinic.Application.Commands.Appointment.UpdatePrice;

public class UpdateAppointmentPriceHandler
    : IRequestHandler<UpdateAppointmentPriceInput>
{
    public Task Handle(
        UpdateAppointmentPriceInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
