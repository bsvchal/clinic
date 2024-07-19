using Clinic.Domain.Interfaces;
using MediatR;

namespace Clinic.Application.Commands.Doctor.Create;

public class CreateDoctorHandler 
    : IRequestHandler<CreateDoctorInput, CreateDoctorOutput>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDoctorHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateDoctorOutput> Handle(
        CreateDoctorInput request, CancellationToken cancellationToken)
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

        var doctor = new Domain.Entities.Doctor
        {
            Id = Guid.NewGuid(),
            IsDeleted = false,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            DateOfBirth = request.DateOfBirth,
            CareerStartYear = request.CareerStartYear,
            IsWorking = true,
            Specialization = request.Specialization,
            OfficeId = request.OfficeId,
            AccountId = accountId.Value,
            Appointments = []
        };
        var createdEntityId = await _unitOfWork.DoctorsRepository
            .CreateAsync(doctor, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
        return new(createdEntityId.Value);
    }
}
