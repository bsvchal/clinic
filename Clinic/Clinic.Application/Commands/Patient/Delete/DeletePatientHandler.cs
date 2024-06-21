using MediatR;

namespace Clinic.Application.Commands.Patient.Delete;

public class DeletePatientHandler
    : IRequestHandler<DeletePatientInput>
{
    public Task Handle(
        DeletePatientInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
