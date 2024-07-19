using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Appointment.Approve;

public class ApproveAppointmentHandler
    : IRequestHandler<ApproveAppointmentInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public ApproveAppointmentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        ApproveAppointmentInput request, CancellationToken cancellationToken)
    {
        var appointment = 
            await _unitOfWork.AppointmentsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (appointment is null)
            throw new ArgumentException($"Appointment with id={request.Id} does not exist or is deleted.");

        appointment.IsApproved = true;
        _unitOfWork.AppointmentsRepository.Update(appointment);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
