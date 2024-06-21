using MediatR;

namespace Clinic.Application.Queries.Office.GetByCity;

public class GetOfficesByCityHandler : IRequestHandler<GetOfficesByCityInput, GetOfficesByCityOutput>
{
    public Task<GetOfficesByCityOutput> Handle(
        GetOfficesByCityInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
