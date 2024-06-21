using MediatR;

namespace Clinic.Application.Queries.Doctor.GetBySpecialization;

public class GetDoctorsBySpecializationHandler
    : IRequestHandler<GetDoctorsBySpecializationInput, GetDoctorsBySpecializationOutput>
{
    public Task<GetDoctorsBySpecializationOutput> Handle(
        GetDoctorsBySpecializationInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
