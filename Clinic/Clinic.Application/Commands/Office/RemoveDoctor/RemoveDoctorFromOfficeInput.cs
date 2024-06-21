using MediatR;

namespace Clinic.Application.Commands.Office.RemoveDoctor;

public record RemoveDoctorFromOfficeInput(
    Guid DoctorId) : IRequest;
