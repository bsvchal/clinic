using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Queries.Receptionist.GetById;

public class GetReceptionistByIdHandler : IRequestHandler<GetReceptionistByIdInput, GetReceptionistByIdOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetReceptionistByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetReceptionistByIdOutput> Handle(
        GetReceptionistByIdInput request, CancellationToken cancellationToken)
    {
        var receptionist = 
            await _unitOfWork.ReceptionistsRepository.GetByIdAsync(request.Id, cancellationToken);
        return new(receptionist);
    }
}
