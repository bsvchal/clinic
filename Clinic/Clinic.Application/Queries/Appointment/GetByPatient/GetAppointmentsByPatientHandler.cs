using MediatR;

namespace Clinic.Application.Queries.Appointment.GetByPatient;

public class GetAppointmentsByPatientHandler : IRequestHandler<GetAppointmentsByPatientInput, GetAppointmentsByPatientOutput>
{
    public Task<GetAppointmentsByPatientOutput> Handle(
        GetAppointmentsByPatientInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
