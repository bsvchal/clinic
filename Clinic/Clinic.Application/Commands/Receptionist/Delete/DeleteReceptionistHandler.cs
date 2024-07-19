using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Receptionist.Delete;

public class DeleteReceptionistHandler
    : IRequestHandler<DeleteReceptionistInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReceptionistHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeleteReceptionistInput request, CancellationToken cancellationToken)
    {
        var receptionist = await _unitOfWork.ReceptionistsRepository
            .GetByIdAsync(request.Id, cancellationToken);
        if (receptionist is null)
            throw new ArgumentException($"Receptionist with id={request.Id} does not exist or is deleted");

        _unitOfWork.ReceptionistsRepository.Delete(receptionist);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
