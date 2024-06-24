using MediatR;

namespace Clinic.Application.Queries.Patient.GetById;

public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdInput, GetPatientByIdOutput>
{
    public Task<GetPatientByIdOutput> Handle(
        GetPatientByIdInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
