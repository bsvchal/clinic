using MediatR;

namespace Clinic.Application.Commands.Photo.Create;

public class CreatePhotoHandler
    : IRequestHandler<CreatePhotoInput, CreatePhotoOutput>
{
    public Task<CreatePhotoOutput> Handle(
        CreatePhotoInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
