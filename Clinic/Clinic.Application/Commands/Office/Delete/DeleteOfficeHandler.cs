using MediatR;

namespace Clinic.Application.Commands.Office.Delete;

public class DeleteOfficeHandler
    : IRequestHandler<DeleteOfficeInput>
{
    public Task Handle(
        DeleteOfficeInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
