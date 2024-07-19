using MediatR;

namespace Clinic.Application.Commands.Doctor.RemoveFromOffice;

public record RemoveDoctorFromOfficeInput(
    Guid DoctorId) : IRequest;
