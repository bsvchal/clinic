using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Doctor.AddToOffice;

public class AddDoctorToOfficeHandler
    : IRequestHandler<AddDoctorToOfficeInput>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddDoctorToOfficeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        AddDoctorToOfficeInput request, CancellationToken cancellationToken)
    {
        var doctor = await _unitOfWork.DoctorsRepository.GetByIdAsync(request.DoctorId, cancellationToken);
        if (doctor is null)
            throw new ArgumentException($"Doctor with id={request.DoctorId} does not exist or is deleted");

        doctor.OfficeId = request.OfficeId;
        _unitOfWork.DoctorsRepository.Update(doctor);

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
