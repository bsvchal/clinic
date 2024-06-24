using MediatR;

namespace Clinic.Application.Commands.Doctor.UpdateWorkingStatus;

public record UpdateDoctorWorkingStatusInput(
    Guid Id,
    bool IsWorking
) : IRequest;
