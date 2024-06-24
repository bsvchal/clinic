using MediatR;

namespace Clinic.Application.Commands.Receptionist.Delete;

public class DeleteReceptionistHandler
    : IRequestHandler<DeleteReceptionistInput>
{
    public Task Handle(
        DeleteReceptionistInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
