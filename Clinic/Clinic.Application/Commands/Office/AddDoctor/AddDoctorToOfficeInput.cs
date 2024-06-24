using MediatR;

namespace Clinic.Application.Commands.Office.AddDoctor;

public record AddDoctorToOfficeInput(
    Guid DoctorId) : IRequest;
