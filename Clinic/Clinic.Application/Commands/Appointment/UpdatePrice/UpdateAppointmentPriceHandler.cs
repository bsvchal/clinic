using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Appointment.UpdatePrice;

public class UpdateAppointmentPriceHandler
    : IRequestHandler<UpdateAppointmentPriceInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAppointmentPriceHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdateAppointmentPriceInput request, CancellationToken cancellationToken)
    {
        var appointment = await _unitOfWork.AppointmentsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (appointment is null)
            throw new ArgumentException($"Appointment with id={request.Id} does not exist or is deleted");

        appointment.Price = request.Price;
        _unitOfWork.AppointmentsRepository.Update(appointment);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
