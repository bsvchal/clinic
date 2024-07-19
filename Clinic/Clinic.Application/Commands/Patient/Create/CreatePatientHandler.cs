using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Patient.Create;

public class CreatePatientHandler
    : IRequestHandler<CreatePatientInput, CreatePatientOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePatientHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreatePatientOutput> Handle(
        CreatePatientInput request, CancellationToken cancellationToken)
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

        var patient = new Domain.Entities.Patient
        {
            Id = Guid.NewGuid(),
            IsDeleted = false,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            DateOfBirth = request.DateOfBirth,
            AccountId = accountId.Value,
            Appointments = []
        };
        var createdEntityId = await _unitOfWork.PatientsRepository
            .CreateAsync(patient,cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
        return new(createdEntityId.Value);
    }
}
