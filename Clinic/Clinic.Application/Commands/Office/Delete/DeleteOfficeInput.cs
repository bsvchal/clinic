using MediatR;

namespace Clinic.Application.Commands.Office.Delete;

public record DeleteOfficeInput(Guid Id) : IRequest;
