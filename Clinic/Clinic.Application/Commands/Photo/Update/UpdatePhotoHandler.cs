using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Photo.Update;

public class UpdatePhotoHandler
    : IRequestHandler<UpdatePhotoInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePhotoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdatePhotoInput request, CancellationToken cancellationToken)
    {
        var photo = await _unitOfWork.PhotosRepository.GetByIdAsync(request.Id, cancellationToken);
        if (photo is null)
            throw new ArgumentException($"Photo with id={request.Id} does not exist or is deleted");

        photo.Path = request.Path;
        _unitOfWork.PhotosRepository.Update(photo);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
