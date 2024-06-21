namespace Clinic.Application.Queries.Appointment.GetByPatient;

public record GetAppointmentsByPatientOutput(
    IEnumerable<Domain.Entities.Appointment> Appointments);
