using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Office.Create;

public class CreateOfficeHandler
    : IRequestHandler<CreateOfficeInput, CreateOfficeOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOfficeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateOfficeOutput> Handle(
        CreateOfficeInput request, CancellationToken cancellationToken)
    {
        var office = new Domain.Entities.Office
        {
            Id = Guid.NewGuid(),
            IsDeleted = false,
            CityName = request.CityName,
            RegistryPhoneNumber = request.RegistryPhoneNumber,
            Doctors = [],
            Receptionists = []
        };
        var createdEntityId = await _unitOfWork.OfficesRepository
            .CreateAsync(office, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
        return new(createdEntityId.Value);
    }
}
