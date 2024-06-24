namespace Clinic.Application.Queries.Doctor.GetByOffice;

public record GetDoctorsByOfficeOutput(
    IEnumerable<Domain.Entities.Doctor> Doctors);
