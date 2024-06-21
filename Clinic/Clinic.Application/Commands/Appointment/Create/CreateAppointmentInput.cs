using MediatR;

namespace Clinic.Application.Commands.Appointment.Create;

public record CreateAppointmentInput(
    Guid PatientId,
    Guid DoctorId,
    decimal Price,
    DateTime SheduledTime
) : IRequest<CreateAppointmentOutput>;
