using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Doctor.RemoveFromOffice;

public class RemoveDoctorFromOfficeHandler
    : IRequestHandler<RemoveDoctorFromOfficeInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveDoctorFromOfficeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        RemoveDoctorFromOfficeInput request, CancellationToken cancellationToken)
    {
        var doctor = await _unitOfWork.DoctorsRepository.GetByIdAsync(request.DoctorId, cancellationToken);
        if (doctor is null)
            throw new ArgumentException($"Doctor with id={request.DoctorId} does not exist or is deleted");

        doctor.Office = null;
        _unitOfWork.DoctorsRepository.Update(doctor);

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
