using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Patient.GetById;

public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdInput, GetPatientByIdOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPatientByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetPatientByIdOutput> Handle(
        GetPatientByIdInput request, CancellationToken cancellationToken)
    {
        var patient = 
            await _unitOfWork.PatientsRepository.GetByIdAsync(request.Id, cancellationToken);
        return new(patient);
    }
}
