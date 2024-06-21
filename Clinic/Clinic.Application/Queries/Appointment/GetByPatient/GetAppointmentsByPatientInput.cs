using MediatR;

namespace Clinic.Application.Queries.Appointment.GetByPatient;

public record GetAppointmentsByPatientInput(Guid PatientId) : IRequest<GetAppointmentsByPatientOutput>;
