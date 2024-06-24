namespace Clinic.Application.Queries.Appointment.GetByDoctor;

public record GetAppointmentsByDoctorOutput(
    IEnumerable<Domain.Entities.Appointment> Appointments);
