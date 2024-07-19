using MediatR;

namespace Clinic.Application.Commands.Doctor.AddToOffice;

public record AddDoctorToOfficeInput(
    Guid OfficeId, Guid DoctorId) : IRequest;
