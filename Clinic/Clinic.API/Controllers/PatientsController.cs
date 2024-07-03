﻿using Clinic.API.Models;
using Clinic.API.Models.Patient;
using Clinic.Application.Commands.Patient.Create;
using Clinic.Application.Commands.Patient.Delete;
using Clinic.Application.Queries.Patient.GetById;
using MediatR;
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
    public async Task<ActionResult> GetPatientByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new GetPatientByIdInput(id),
            cancellationToken
        );

        if (result.Patient is null)
            return NotFound();

        return Ok(
            new PatientResponse(result.Patient)
        );
    }

    [HttpPost]
    public async Task<ActionResult> CreatePatientAsync(
        PatientCreationRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new CreatePatientInput(
                request.Email,
                request.Password,
                request.PhoneNumber,
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.DateOfBirth
            ),
            cancellationToken
        );
        return Ok(
            new CreatedEntityResponse(result.Id)    
        );
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePatientAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new DeletePatientInput(id),
            cancellationToken
        );

        return NoContent();
    }
}
