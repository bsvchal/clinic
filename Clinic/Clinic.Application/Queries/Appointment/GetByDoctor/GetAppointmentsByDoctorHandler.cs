using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Appointment.GetByDoctor;

public class GetAppointmentsByDoctorHandler 
    : IRequestHandler<GetAppointmentsByDoctorInput, GetAppointmentsByDoctorOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAppointmentsByDoctorHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetAppointmentsByDoctorOutput> Handle(
        GetAppointmentsByDoctorInput request, CancellationToken cancellationToken)
    {
        var appointments = 
            await _unitOfWork.AppointmentsRepository.GetAsync(cancellationToken: cancellationToken);
        return new(appointments.Where(a => a.DoctorId == request.DoctorId));
    }
}
