namespace Clinic.Application.Queries.Doctor.GetBySpecialization;

public record GetDoctorsBySpecializationOutput(
    IEnumerable<Domain.Entities.Doctor> Doctors);
