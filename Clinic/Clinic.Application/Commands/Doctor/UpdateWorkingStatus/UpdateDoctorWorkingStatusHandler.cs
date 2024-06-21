using MediatR;

namespace Clinic.Application.Commands.Doctor.UpdateWorkingStatus;

public class UpdateDoctorWorkingStatusHandler
    : IRequestHandler<UpdateDoctorWorkingStatusInput>
{
    public Task Handle(
        UpdateDoctorWorkingStatusInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
