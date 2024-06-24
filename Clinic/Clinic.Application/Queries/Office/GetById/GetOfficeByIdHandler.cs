using MediatR;

namespace Clinic.Application.Queries.Office.GetById;

public class GetOfficeByIdHandler : IRequestHandler<GetOfficeByIdInput, GetOfficeByIdOutput>
{
    public Task<GetOfficeByIdOutput> Handle(
        GetOfficeByIdInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
