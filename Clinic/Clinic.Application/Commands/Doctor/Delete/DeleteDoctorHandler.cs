using MediatR;

namespace Clinic.Application.Commands.Doctor.Delete;

public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorInput>
{
    public Task Handle(
        DeleteDoctorInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
