using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Doctor.GetByOffice;

public class GetDoctorsByOfficeHandler : IRequestHandler<GetDoctorsByOfficeInput, GetDoctorsByOfficeOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDoctorsByOfficeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetDoctorsByOfficeOutput> Handle(
        GetDoctorsByOfficeInput request, CancellationToken cancellationToken)
    {
        var doctors =
            await _unitOfWork.DoctorsRepository.GetAsync(cancellationToken: cancellationToken);
        return new(doctors.Where(d => d.OfficeId == request.OfficeId));
    }
}
