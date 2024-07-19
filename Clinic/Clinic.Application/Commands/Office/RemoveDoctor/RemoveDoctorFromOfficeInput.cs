using MediatR;

namespace Clinic.Application.Commands.Office.RemoveDoctor;

public record RemoveDoctorFromOfficeInput(
    Guid OfficeId,
    Guid DoctorId) : IRequest;
