using MediatR;

namespace Clinic.Application.Commands.Office.RemoveDoctor;

public class RemoveDoctorFromOfficeHandler
    : IRequestHandler<RemoveDoctorFromOfficeInput>
{
    public Task Handle(
        RemoveDoctorFromOfficeInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
