using MediatR;

namespace Clinic.Application.Queries.Appointment.GetById;

public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdInput, GetAppointmentByIdOutput>
{
    public Task<GetAppointmentByIdOutput> Handle(
        GetAppointmentByIdInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
