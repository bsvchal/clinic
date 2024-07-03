using Clinic.API.Models;
using Clinic.API.Models.Appointment;
using Clinic.Application.Commands.Appointment.Approve;
using Clinic.Application.Commands.Appointment.Create;
using Clinic.Application.Commands.Appointment.Delete;
using Clinic.Application.Commands.Appointment.UpdatePrice;
using Clinic.Application.Commands.Appointment.UpdateScheduledTime;
using Clinic.Application.Queries.Appointment.GetByDoctor;
using Clinic.Application.Queries.Appointment.GetById;
using Clinic.Application.Queries.Appointment.GetByPatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetAppointmentByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetAppointmentByIdInput(id), cancellationToken);

        if (result.Appointment is null)
            return NotFound();

        return Ok(
            new AppointmentResponse(result.Appointment)
        );
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<ActionResult> GetAppointmentsByDoctorAsync(
        Guid doctorId, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new GetAppointmentsByDoctorInput(doctorId),
            cancellationToken
        );

        return Ok(
            result.Appointments.Select(a => new AppointmentResponse(a))    
        );
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult> GetAppointmentsByPatientAsync(
        Guid patientId, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new GetAppointmentsByPatientInput(patientId),
            cancellationToken
        );

        return Ok(
            result.Appointments.Select(a => new AppointmentResponse(a))    
        );
    }
        
    [HttpPost]
    public async Task<ActionResult> CreateAppointmentAsync(
        AppointmentCreationRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new CreateAppointmentInput(
                request.PatientId,
                request.DoctorId,
                request.Price,
                request.ScheduledTime
            ),
            cancellationToken
        );
        return Ok(
            new CreatedEntityResponse(result.Id)
        );
    }

    [HttpPut("{id}/approve")]
    public async Task<ActionResult> ApproveAppointmentAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new ApproveAppointmentInput(id),
            cancellationToken
        );

        return NoContent();
    }

    [HttpPut("{id}/price")]
    public async Task<ActionResult> UpdateAppointmentPriceAsync(
        Guid id, AppointmentUpdatePriceRequest request, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new UpdateAppointmentPriceInput(id, request.Price),
            cancellationToken
        );

        return NoContent();
    }

    [HttpPut("{id}/scheduled-time")]
    public async Task<ActionResult> UpdateAppointmentScheduledTimeAsync(
        Guid id, AppointmentUpdateScheduledTimeRequest request, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new UpdateAppointmentScheduledTimeInput(id, request.ScheduledTime),
            cancellationToken
        );

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAppointmentAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new DeleteAppointmentInput(id),
            cancellationToken
        );

        return NoContent();
    }
}
