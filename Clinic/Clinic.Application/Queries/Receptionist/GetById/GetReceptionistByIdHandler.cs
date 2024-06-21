using MediatR;

namespace Clinic.Application.Queries.Receptionist.GetById;

public class GetReceptionistByIdHandler : IRequestHandler<GetReceptionistByIdInput, GetReceptionistByIdOutput>
{
    public Task<GetReceptionistByIdOutput> Handle(
        GetReceptionistByIdInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
