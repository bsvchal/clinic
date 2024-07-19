using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Doctor.GetById;

public class GetDoctorByIdHandler : IRequestHandler<GetDoctorByIdInput, GetDoctorByIdOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDoctorByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetDoctorByIdOutput> Handle(
        GetDoctorByIdInput request, CancellationToken cancellationToken)
    {
        var doctor =
            await _unitOfWork.DoctorsRepository.GetByIdAsync(request.Id, cancellationToken);
        return new(doctor);
    }
}
