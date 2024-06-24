using MediatR;

namespace Clinic.Application.Queries.Doctor.GetById;

public class GetDoctorByIdHandler : IRequestHandler<GetDoctorByIdInput, GetDoctorByIdOutput>
{
    public Task<GetDoctorByIdOutput> Handle(
        GetDoctorByIdInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
