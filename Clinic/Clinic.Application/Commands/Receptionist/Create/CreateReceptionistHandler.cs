using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Receptionist.Create;

public class CreateReceptionistHandler
    : IRequestHandler<CreateReceptionistInput, CreateReceptionistOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateReceptionistHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateReceptionistOutput> Handle(
        CreateReceptionistInput request, CancellationToken cancellationToken)
    {
        var account = new Domain.Entities.Account
        {
            Id = Guid.NewGuid(),
            IsDeleted = false,
            Email = request.Email,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber,
            IsEmailVerified = false,
            CreatedAt = DateTime.UtcNow,
        };
        var accountId = await _unitOfWork.AccountsRepository
            .CreateAsync(account, cancellationToken);

        var receptionist = new Domain.Entities.Receptionist
        {
            Id = Guid.NewGuid(),
            IsDeleted = false,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            AccountId = accountId.Value,
            OfficeId = request.OfficeId
        };
        var createdEntityId = await _unitOfWork.ReceptionistsRepository
            .CreateAsync(receptionist, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
        return new(createdEntityId.Value);
    }
}
