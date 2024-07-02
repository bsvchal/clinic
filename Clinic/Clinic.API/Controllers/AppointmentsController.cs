using Clinic.API.Models;
using Clinic.API.Models.Appointment;
using Clinic.API.Models.Doctor;
using Clinic.API.Models.Patient;
using Clinic.Application.Commands.Appointment.Create;
using Clinic.Application.Queries.Appointment.GetById;
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
    public async Task<ActionResult> GetAppointmentByIdAsync(Guid id)
    {
        var result = await _mediator.Send(new GetAppointmentByIdInput(id));

        if (result.Appointment is null)
            return NotFound();

        return Ok(
            new Appointment(result.Appointment)
        );
    }
        
    [HttpPost]
    public async Task<ActionResult> CreateAppointmentAsync(
        AppointmentForCreation request)
    {
        var result = await _mediator.Send(
            new CreateAppointmentInput(
                request.PatientId,
                request.DoctorId,
                request.Price,
                request.ScheduledTime
            )
        );
        return Ok(
            new CreateEntityOutput(result.Id)
        );
    }
}
