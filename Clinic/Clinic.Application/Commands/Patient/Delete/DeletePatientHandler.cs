using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Patient.Delete;

public class DeletePatientHandler
    : IRequestHandler<DeletePatientInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePatientHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeletePatientInput request, CancellationToken cancellationToken)
    {
        var patient = await _unitOfWork.PatientsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (patient is null)
            throw new ArgumentException($"Patient with id={request.Id} does not exist or is deleted");

        _unitOfWork.PatientsRepository.Delete(patient);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
