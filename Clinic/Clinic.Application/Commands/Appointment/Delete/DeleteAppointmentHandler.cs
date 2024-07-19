using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Appointment.Delete;

public class DeleteAppointmentHandler
    : IRequestHandler<DeleteAppointmentInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAppointmentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeleteAppointmentInput request, CancellationToken cancellationToken)
    {
        var appointment = await _unitOfWork.AppointmentsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (appointment is null)
            throw new ArgumentException($"Appointment with id={request.Id} does not exist or is deleted");

        _unitOfWork.AppointmentsRepository.Delete(appointment);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
