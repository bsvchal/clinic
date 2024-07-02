using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Appointment.GetByPatient;

public class GetAppointmentsByPatientHandler 
    : IRequestHandler<GetAppointmentsByPatientInput, GetAppointmentsByPatientOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAppointmentsByPatientHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetAppointmentsByPatientOutput> Handle(
        GetAppointmentsByPatientInput request, CancellationToken cancellationToken)
    {
        var appointments =
            await _unitOfWork.AppointmentsRepository.GetAsync(cancellationToken: cancellationToken);
        return new(appointments.Where(a => a.PatientId == request.PatientId));
    }
}
