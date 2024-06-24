using MediatR;

namespace Clinic.Application.Commands.Patient.Create;

public class CreatePatientHandler
    : IRequestHandler<CreatePatientInput, CreatePatientOutput>
{
    public Task<CreatePatientOutput> Handle(
        CreatePatientInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
