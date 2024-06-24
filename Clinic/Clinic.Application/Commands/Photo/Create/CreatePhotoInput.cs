using MediatR;

namespace Clinic.Application.Commands.Photo.Create;

public record CreatePhotoInput(
    string Path,
    Guid AccountId
) : IRequest<CreatePhotoOutput>;
