using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Office.Update;

public class UpdateOfficeHandler
    : IRequestHandler<UpdateOfficeInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOfficeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdateOfficeInput request, CancellationToken cancellationToken)
    {
        var office = await _unitOfWork.OfficesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (office is null)
            throw new ArgumentException($"Office with id={request.Id} does not exist or is deleted");

        office.RegistryPhoneNumber = request.RegistryPhoneNumber;
        _unitOfWork.OfficesRepository.Update(office);

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
