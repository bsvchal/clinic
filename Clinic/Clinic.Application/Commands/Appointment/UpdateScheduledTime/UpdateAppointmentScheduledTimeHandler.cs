using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Appointment.UpdateScheduledTime;

public class UpdateAppointmentScheduledTimeHandler
    : IRequestHandler<UpdateAppointmentScheduledTimeInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAppointmentScheduledTimeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdateAppointmentScheduledTimeInput request, CancellationToken cancellationToken)
    {
        var appointment = await _unitOfWork.AppointmentsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (appointment is null)
            throw new ArgumentException($"Appointment with id={request.Id} does not exist or is deleted");

        appointment.ScheduledTime = request.ScheduledTime;
        _unitOfWork.AppointmentsRepository.Update(appointment);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
