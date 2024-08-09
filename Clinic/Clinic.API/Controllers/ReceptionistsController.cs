using Clinic.API.Models;
using Clinic.API.Models.Receptionist;
using Clinic.Application.Commands.Receptionist.Delete;
using Clinic.Application.Queries.Receptionist.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Clinic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReceptionistsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReceptionistsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetReceptionistByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        var result = await _mediator.Send(
            new GetReceptionistByIdInput(id),
            cancellationToken
        );

        if (result.Receptionist is null)
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
            result.Receptionist    
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

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteReceptionistAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        await _mediator.Send(
            new DeleteReceptionistInput(id),
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
