using MediatR;

namespace Clinic.Application.Commands.Office.Create;

public class CreateOfficeHandler
    : IRequestHandler<CreateOfficeInput, CreateOfficeOutput>
{
    public Task<CreateOfficeOutput> Handle(
        CreateOfficeInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
