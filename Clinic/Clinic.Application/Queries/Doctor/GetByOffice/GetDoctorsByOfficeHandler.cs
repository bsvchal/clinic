using MediatR;

namespace Clinic.Application.Queries.Doctor.GetByOffice;

public class GetDoctorsByOfficeHandler : IRequestHandler<GetDoctorsByOfficeInput, GetDoctorsByOfficeOutput>
{
    public Task<GetDoctorsByOfficeOutput> Handle(
        GetDoctorsByOfficeInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
