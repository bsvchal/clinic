using MediatR;

namespace Clinic.Application.Commands.Office.AddDoctor;

public record AddDoctorToOfficeInput(
    Guid OfficeId,
    Guid DoctorId) : IRequest;
