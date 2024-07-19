using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Office.GetByCity;

public class GetOfficesByCityHandler : IRequestHandler<GetOfficesByCityInput, GetOfficesByCityOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOfficesByCityHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetOfficesByCityOutput> Handle(
        GetOfficesByCityInput request, CancellationToken cancellationToken)
    {
        var offices =
            await _unitOfWork.OfficesRepository.GetAsync(cancellationToken: cancellationToken);
        return new(offices.Where(o => o.CityName == request.CityName));
    }
}
