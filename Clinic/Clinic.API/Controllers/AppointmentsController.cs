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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Clinic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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
        var start = DateTime.Now;
        var result = await _mediator.Send(new GetAppointmentByIdInput(id), cancellationToken);

        if (result.Appointment is null)
        {
            Log.Information(
                "{Now} - Request On: {Path}; Method: {Method}; Body: {@Body}; Response: {@Response}; Status: {StatusCode}; Completed In: {CompletedIn} ms",
                DateTime.Now,
                HttpContext.Request.Path,
                HttpContext.Request.Method,
                new { },
                new { },
                StatusCodes.Status404NotFound,
                (DateTime.Now - start).TotalMilliseconds
            );
            return NotFound();
        }

        var response = Ok(
            new AppointmentResponse(result.Appointment)
        );
        Log.Information(
            "{Now} - Request On: {Path}; Method: {Method}; Body: {@Body}; Response: {@Response}; Status: {StatusCode}; Completed In: {CompletedIn} ms",
            DateTime.Now,
            HttpContext.Request.Path,
            HttpContext.Request.Method,
            new { },
            response.Value,
            response.StatusCode,
            (DateTime.Now - start).TotalMilliseconds
        );
        return response;
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<ActionResult> GetAppointmentsByDoctorAsync(
        Guid doctorId, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        var result = await _mediator.Send(
            new GetAppointmentsByDoctorInput(doctorId),
            cancellationToken
        );

        var response = Ok(
            result.Appointments.Select(a => new AppointmentResponse(a))    
        );
        Log.Information(
            "{Now} - Request On: {Path}; Method: {Method}; Body: {@Body}; Response: {@Response}; Status: {StatusCode}; Completed In: {CompletedIn} ms",
            DateTime.Now,
            HttpContext.Request.Path,
            HttpContext.Request.Method,
            new { },
            response.Value,
            response.StatusCode,
            (DateTime.Now - start).TotalMilliseconds
        );
        return response;
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult> GetAppointmentsByPatientAsync(
        Guid patientId, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        var result = await _mediator.Send(
            new GetAppointmentsByPatientInput(patientId),
            cancellationToken
        );

        var response = Ok(
            result.Appointments.Select(a => new AppointmentResponse(a))    
        );
        Log.Information(
            "{Now} - Request On: {Path}; Method: {Method}; Body: {@Body}; Response: {@Response}; Status: {StatusCode}; Completed In: {CompletedIn} ms",
            DateTime.Now,
            HttpContext.Request.Path,
            HttpContext.Request.Method,
            new { },
            response.Value,
            response.StatusCode,
            (DateTime.Now - start).TotalMilliseconds
        );
        return response;
    }
        
    [HttpPost]
    public async Task<ActionResult> CreateAppointmentAsync(
        AppointmentCreationRequest request, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        var result = await _mediator.Send(
            new CreateAppointmentInput(
                request.PatientId,
                request.DoctorId,
                request.Price,
                request.ScheduledTime
            ),
            cancellationToken
        );

        var response = Ok(
            new CreatedEntityResponse(result.Id)
        );
        Log.Information(
            "{Now} - Request On: {Path}; Method: {Method}; Body: {@Body}; Response: {@Response}; Status: {StatusCode}; Completed In: {CompletedIn} ms",
            DateTime.Now,
            HttpContext.Request.Path,
            HttpContext.Request.Method,
            request,
            response.Value,
            response.StatusCode,
            (DateTime.Now - start).TotalMilliseconds
        );
        return response;
    }

    [HttpPut("{id}/approve")]
    public async Task<ActionResult> ApproveAppointmentAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        await _mediator.Send(
            new ApproveAppointmentInput(id),
            cancellationToken
        );

        Log.Information(
            "{Now} - Request On: {Path}; Method: {Method}; Body: {@Body}; Response: {@Response}; Status: {StatusCode}; Completed In: {CompletedIn} ms",
            DateTime.Now,
            HttpContext.Request.Path,
            HttpContext.Request.Method,
            new { },
            new { },
            StatusCodes.Status204NoContent,
            (DateTime.Now - start).TotalMilliseconds
        );
        return NoContent();
    }

    [HttpPut("{id}/price")]
    public async Task<ActionResult> UpdateAppointmentPriceAsync(
        Guid id, AppointmentUpdatePriceRequest request, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        await _mediator.Send(
            new UpdateAppointmentPriceInput(id, request.Price),
            cancellationToken
        );

        Log.Information(
            "{Now} - Request On: {Path}; Method: {Method}; Body: {@Body}; Response: {@Response}; Status: {StatusCode}; Completed In: {CompletedIn} ms",
            DateTime.Now,
            HttpContext.Request.Path,
            HttpContext.Request.Method,
            request,
            new { },
            StatusCodes.Status204NoContent,
            (DateTime.Now - start).TotalMilliseconds
        );
        return NoContent();
    }

    [HttpPut("{id}/scheduled-time")]
    public async Task<ActionResult> UpdateAppointmentScheduledTimeAsync(
        Guid id, AppointmentUpdateScheduledTimeRequest request, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        await _mediator.Send(
            new UpdateAppointmentScheduledTimeInput(id, request.ScheduledTime),
            cancellationToken
        );

        Log.Information(
            "{Now} - Request On: {Path}; Method: {Method}; Body: {@Body}; Response: {@Response}; Status: {StatusCode}; Completed In: {CompletedIn} ms",
            DateTime.Now,
            HttpContext.Request.Path,
            HttpContext.Request.Method,
            request,
            new { },
            StatusCodes.Status204NoContent,
            (DateTime.Now - start).TotalMilliseconds
        );
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAppointmentAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        await _mediator.Send(
            new DeleteAppointmentInput(id),
            cancellationToken
        );

        Log.Information(
            "{Now} - Request On: {Path}; Method: {Method}; Body: {@Body}; Response: {@Response}; Status: {StatusCode}; Completed In: {CompletedIn} ms",
            DateTime.Now,
            HttpContext.Request.Path,
            HttpContext.Request.Method,
            new { },
            new { },
            StatusCodes.Status204NoContent,
            (DateTime.Now - start).TotalMilliseconds
        );
        return NoContent();
    }
}
