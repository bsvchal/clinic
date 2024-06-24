using MediatR;

namespace Clinic.Application.Commands.Photo.Delete;

public record DeletePhotoInput(Guid Id) : IRequest;
