using MediatR;

namespace Clinic.Application.Commands.Office.AddDoctor;

public class AddDoctorToOfficeHandler
    : IRequestHandler<AddDoctorToOfficeInput>
{
    public Task Handle(
        AddDoctorToOfficeInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
