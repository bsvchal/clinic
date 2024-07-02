using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Doctor.GetBySpecialization;

public class GetDoctorsBySpecializationHandler
    : IRequestHandler<GetDoctorsBySpecializationInput, GetDoctorsBySpecializationOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDoctorsBySpecializationHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetDoctorsBySpecializationOutput> Handle(
        GetDoctorsBySpecializationInput request, CancellationToken cancellationToken)
    {
        var doctors =
            await _unitOfWork.DoctorsRepository.GetAsync(cancellationToken: cancellationToken);
        return new(doctors.Where(d => d.Specialization == request.Specialization));
    }
}
