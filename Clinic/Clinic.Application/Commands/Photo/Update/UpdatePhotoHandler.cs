using MediatR;

namespace Clinic.Application.Commands.Photo.Update;

public class UpdatePhotoHandler
    : IRequestHandler<UpdatePhotoInput>
{
    public Task Handle(
        UpdatePhotoInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
