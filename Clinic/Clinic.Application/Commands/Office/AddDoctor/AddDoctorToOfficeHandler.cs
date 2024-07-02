using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Office.AddDoctor;

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
        var office = await _unitOfWork.OfficesRepository.GetByIdAsync(request.OfficeId, cancellationToken);
        if (office is null)
            throw new ArgumentException($"Office with id={request.OfficeId} does not exist or is deleted");
        var doctor = await _unitOfWork.DoctorsRepository.GetByIdAsync(request.DoctorId, cancellationToken);
        if (doctor is null)
            throw new ArgumentException($"Doctor with id={request.DoctorId} does not exist or is deleted");

        doctor.Office = office;
        office.Doctors.Add(doctor);
        _unitOfWork.OfficesRepository.Update(office);
        _unitOfWork.DoctorsRepository.Update(doctor);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
