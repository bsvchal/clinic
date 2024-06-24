using MediatR;

namespace Clinic.Application.Commands.Doctor.Create;

public class CreateDoctorHandler 
    : IRequestHandler<CreateDoctorInput, CreateDoctorOutput>
{
    public Task<CreateDoctorOutput> Handle(
        CreateDoctorInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
