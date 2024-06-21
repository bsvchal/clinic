using MediatR;

namespace Clinic.Application.Commands.Photo.Delete;

public class DeletePhotoHandler
    : IRequestHandler<DeletePhotoInput>
{
    public Task Handle(
        DeletePhotoInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
