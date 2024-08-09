namespace IdentityServer.Infrastructure.Contracts;

public record PatientCreationModel(
    string Id,
    string FirstName,
    string MiddleName,
    string LastName,
    DateOnly DateOfBirth
);
