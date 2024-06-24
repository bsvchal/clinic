using MediatR;

namespace Clinic.Application.Commands.Office.Update;

public class UpdateOfficeHandler
    : IRequestHandler<UpdateOfficeInput>
{
    public Task Handle(
        UpdateOfficeInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
