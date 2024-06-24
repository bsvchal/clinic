using MediatR;

namespace Clinic.Application.Commands.Receptionist.Create;

public class CreateReceptionistHandler
    : IRequestHandler<CreateReceptionistInput, CreateReceptionistOutput>
{
    public Task<CreateReceptionistOutput> Handle(
        CreateReceptionistInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
