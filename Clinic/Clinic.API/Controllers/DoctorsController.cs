using Clinic.API.Models;
using Clinic.API.Models.Doctor;
using Clinic.Application.Commands.Doctor.Create;
using Clinic.Application.Queries.Doctor.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetDoctorByIdAsync(Guid id)
    {
        var result = await _mediator.Send(new GetDoctorByIdInput(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateDoctorAsync(
        DoctorForCreation request)
    {
        var result = await _mediator.Send(
            new CreateDoctorInput(
                request.Email,
                request.Password,
                request.PhoneNumber,
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.DateOfBirth,
                request.CareerStartYear,
                request.Specialization,
                request.OfficeId
            )
        );
        return Ok(
            new CreateEntityOutput(result.Id)   
        ); 
    }
}
