using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Appointment.Create;

public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentInput, CreateAppointmentOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAppointmentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateAppointmentOutput> Handle(
        CreateAppointmentInput request, CancellationToken cancellationToken)
    {
        var appointment = new Domain.Entities.Appointment
        {
            Id = Guid.NewGuid(),
            IsDeleted = false,
            IsApproved = false,
            ScheduledTime = request.SheduledTime,
            Price = request.Price,
            PatientId = request.PatientId,
            DoctorId = request.DoctorId
        };
        // TODO: add try-catch or no
        var createdEntityId = await _unitOfWork.AppointmentsRepository
            .CreateAsync(appointment, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
        return new(createdEntityId.Value);
    }
}
