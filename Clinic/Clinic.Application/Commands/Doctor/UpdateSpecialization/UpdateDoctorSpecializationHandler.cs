using MediatR;

namespace Clinic.Application.Commands.Doctor.UpdateSpecialization;

public class UpdateDoctorSpecializationHandler
    : IRequestHandler<UpdateDoctorSpecializationInput>
{
    public Task Handle(
        UpdateDoctorSpecializationInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
