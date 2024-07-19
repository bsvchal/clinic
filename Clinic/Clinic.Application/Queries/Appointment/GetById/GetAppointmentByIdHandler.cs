using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Appointment.GetById;

public class GetAppointmentByIdHandler 
    : IRequestHandler<GetAppointmentByIdInput, GetAppointmentByIdOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAppointmentByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetAppointmentByIdOutput> Handle(
        GetAppointmentByIdInput request, CancellationToken cancellationToken)
    {
        var appointemnt = 
            await _unitOfWork.AppointmentsRepository.GetByIdAsync(request.Id, cancellationToken);
        return new(appointemnt);
    }
}
