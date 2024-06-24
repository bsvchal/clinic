using MediatR;

namespace Clinic.Application.Commands.Photo.Update;

public record UpdatePhotoInput(string Path) : IRequest;
