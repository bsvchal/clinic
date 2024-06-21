using MediatR;

namespace Clinic.Application.Queries.Appointment.GetByDoctor;

public record GetAppointmentsByDoctorInput(Guid DoctorId) : IRequest<GetAppointmentsByDoctorOutput>;
