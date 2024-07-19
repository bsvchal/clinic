using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Doctor.Delete;

public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDoctorHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeleteDoctorInput request, CancellationToken cancellationToken)
    {
        var doctor = await _unitOfWork.DoctorsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (doctor is null)
            throw new ArgumentException($"Doctor with id={request.Id} does not exist or is deleted");

        _unitOfWork.DoctorsRepository.Delete(doctor);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
