using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Photo.Create;

public class CreatePhotoHandler
    : IRequestHandler<CreatePhotoInput, CreatePhotoOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePhotoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreatePhotoOutput> Handle(
        CreatePhotoInput request, CancellationToken cancellationToken)
    {
        var photo = new Domain.Entities.Photo
        {
            Id = Guid.NewGuid(),
            IsDeleted = false,
            Path = request.Path,
            AccountId = request.AccountId
        };
        var createdEntityId = await _unitOfWork.PhotosRepository
            .CreateAsync(photo, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
        return new(createdEntityId.Value);
    }
}
