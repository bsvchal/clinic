using Clinic.Domain.Interfaces;
using MediatR;
using MediatR.Wrappers;

namespace Clinic.Application.Commands.Office.RemoveDoctor;

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
        var office = await _unitOfWork.OfficesRepository.GetByIdAsync(request.OfficeId, cancellationToken);
        if (office is null)
            throw new ArgumentException($"Office with id={request.OfficeId} does not exist or is deleted");
        var doctor = await _unitOfWork.DoctorsRepository.GetByIdAsync(request.DoctorId, cancellationToken);
        if (doctor is null)
            throw new ArgumentException($"Doctor with id={request.DoctorId} does not exist or is deleted");

        doctor.Office = null;
        office.Doctors.Remove(doctor);
        _unitOfWork.DoctorsRepository.Update(doctor);
        _unitOfWork.OfficesRepository.Update(office);

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
