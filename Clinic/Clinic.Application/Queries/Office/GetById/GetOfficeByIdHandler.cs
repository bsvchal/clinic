using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Office.GetById;

public class GetOfficeByIdHandler : IRequestHandler<GetOfficeByIdInput, GetOfficeByIdOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOfficeByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetOfficeByIdOutput> Handle(
        GetOfficeByIdInput request, CancellationToken cancellationToken)
    {
        var office = 
            await _unitOfWork.OfficesRepository.GetByIdAsync(request.Id, cancellationToken);
        return new(office);
    }
}
