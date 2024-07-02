using Clinic.Application.Commands.Patient.Create;
using Clinic.Application.Queries.Patient.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<GetPatientByIdOutput> GetPatientByIdAsync(Guid id)
    {
        var response = await _mediator.Send(new GetPatientByIdInput(id));
        return response;
    }

    [HttpPost]
    public async Task<CreatePatientOutput> CreatePatientAsync(
        CreatePatientInput request)
    {
        var output = await _mediator.Send(
            new CreatePatientInput(
                request.Email,
                request.Password,
                request.PhoneNumber,
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.DateOfBirth
            )    
        );
        return output;
    }
}
