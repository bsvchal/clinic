using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Doctor.UpdateSpecialization;

public class UpdateDoctorSpecializationHandler
    : IRequestHandler<UpdateDoctorSpecializationInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDoctorSpecializationHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdateDoctorSpecializationInput request, CancellationToken cancellationToken)
    {
        var doctor = await _unitOfWork.DoctorsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (doctor is null)
            throw new ArgumentException($"Doctor with id={request.Id} does not exist or is deleted");

        doctor.Specialization = request.Specialization;
        _unitOfWork.DoctorsRepository.Update(doctor);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
