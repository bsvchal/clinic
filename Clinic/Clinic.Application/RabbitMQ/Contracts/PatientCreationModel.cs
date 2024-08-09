namespace Clinic.Application.RabbitMQ.Contracts;

public record PatientCreationModel(
    Guid Id,
    string Email,
    string FirstName,
    string MiddleName,
    string LastName,
    DateOnly DateOfBirth
);
