using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Office.Delete;

public class DeleteOfficeHandler
    : IRequestHandler<DeleteOfficeInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOfficeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeleteOfficeInput request, CancellationToken cancellationToken)
    {
        var office = await _unitOfWork.OfficesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (office is null)
            throw new ArgumentException($"Office with id={request.Id} does not exist or is deleted");

        _unitOfWork.OfficesRepository.Delete(office);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
