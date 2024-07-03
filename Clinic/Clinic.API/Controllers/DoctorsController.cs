using Clinic.API.Models;
using Clinic.API.Models.Doctor;
using Clinic.Application.Commands.Doctor.AddToOffice;
using Clinic.Application.Commands.Doctor.Create;
using Clinic.Application.Commands.Doctor.Delete;
using Clinic.Application.Commands.Doctor.RemoveFromOffice;
using Clinic.Application.Commands.Doctor.UpdateSpecialization;
using Clinic.Application.Commands.Doctor.UpdateWorkingStatus;
using Clinic.Application.Queries.Doctor.GetById;
using Clinic.Application.Queries.Doctor.GetByOffice;
using Clinic.Application.Queries.Doctor.GetBySpecialization;
using MediatR;
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
    public async Task<ActionResult> GetDoctorByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new GetDoctorByIdInput(id),
            cancellationToken
        );

        if (result.Doctor is null)
            return NotFound();

        return Ok(
            new DoctorResponse(result.Doctor)
        );
    }

    [HttpGet("office/{officeId}")]
    public async Task<ActionResult> GetDoctorsByOfficeAsync(
        Guid officeId, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new GetDoctorsByOfficeInput(officeId),
            cancellationToken
        );

        return Ok(
            result.Doctors.Select(d => new DoctorResponse(d))    
        );
    }

    [HttpGet("specialization/{specialization}")]
    public async Task<ActionResult> GetDoctorsBySpecializationAsync(
        string specialization, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new GetDoctorsBySpecializationInput(specialization),
            cancellationToken
        );

        return Ok(
            result.Doctors.Select(d => new DoctorResponse(d))
        );
    }

    [HttpPost]
    public async Task<ActionResult> CreateDoctorAsync(
        DoctorCreationRequest request, CancellationToken cancellationToken = default)
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
            ),
            cancellationToken
        );
        return Ok(
            new CreatedEntityResponse(result.Id)
        ); 
    }

    [HttpPut("{id}/add")]
    public async Task<ActionResult> AddDoctorToOfficeAsync(
        Guid id, AddDoctorToOfficeRequest request, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new AddDoctorToOfficeInput(request.OfficeId, id),
            cancellationToken
        );

        return NoContent();
    }

    [HttpPut("{id}/remove")]
    public async Task<ActionResult> RemoveDoctorFromOfficeAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new RemoveDoctorFromOfficeInput(id),
            cancellationToken
        );

        return NoContent();
    }

    [HttpPut("{id}/specialization")]
    public async Task<ActionResult> UpdateDoctorSpecializationAsync(
        Guid id, DoctorUpdateSpecializationRequest request, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new UpdateDoctorSpecializationInput(id, request.Specialization),
            cancellationToken
        );

        return NoContent();
    }

    [HttpPut("{id}/status")]
    public async Task<ActionResult> UpdateDoctorWorkingStatusAsync(
        Guid id, DoctorUpdateWorkingStatusRequest request, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new UpdateDoctorWorkingStatusInput(id, request.IsWorking),
            cancellationToken
        );

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDoctorAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new DeleteDoctorInput(id),
            cancellationToken
        );

        return NoContent();
    }
}
