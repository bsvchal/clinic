namespace Clinic.API.Models.Photo;

public record PhotoCreationRequest(
    string Path, Guid AccountId);
