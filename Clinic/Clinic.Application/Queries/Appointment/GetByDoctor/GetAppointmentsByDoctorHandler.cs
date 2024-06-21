using MediatR;

namespace Clinic.Application.Queries.Appointment.GetByDoctor;

public class GetAppointmentsByDoctorHandler : IRequestHandler<GetAppointmentsByDoctorInput, GetAppointmentsByDoctorOutput>
{
    public Task<GetAppointmentsByDoctorOutput> Handle(
        GetAppointmentsByDoctorInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
