using MediatR;

namespace Clinic.Application.Commands.Photo.Update;

public record UpdatePhotoInput(Guid Id, string Path) : IRequest;
