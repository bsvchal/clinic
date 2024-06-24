using MediatR;

namespace Clinic.Application.Commands.Appointment.UpdatePrice;

public record UpdateAppointmentPriceInput(
    Guid Id,
    decimal Price
) : IRequest;
