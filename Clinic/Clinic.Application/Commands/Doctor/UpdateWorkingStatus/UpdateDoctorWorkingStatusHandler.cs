using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Doctor.UpdateWorkingStatus;

public class UpdateDoctorWorkingStatusHandler
    : IRequestHandler<UpdateDoctorWorkingStatusInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDoctorWorkingStatusHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdateDoctorWorkingStatusInput request, CancellationToken cancellationToken)
    {
        var doctor = await _unitOfWork.DoctorsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (doctor is null)
            throw new ArgumentException($"Doctor with id={request.Id} does not exist or is deleted");

        doctor.IsWorking = request.IsWorking;
        _unitOfWork.DoctorsRepository.Update(doctor);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
