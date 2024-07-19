using Clinic.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clinic.Application.Commands.Photo.Delete;

public class DeletePhotoHandler
    : IRequestHandler<DeletePhotoInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePhotoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeletePhotoInput request, CancellationToken cancellationToken)
    {
        var photo = await _unitOfWork.PhotosRepository.GetByIdAsync(request.Id, cancellationToken);
        if (photo is null)
            throw new ArgumentException($"Photo with id={request.Id} does not exist or is deleted");

        _unitOfWork.PhotosRepository.Delete(photo);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
