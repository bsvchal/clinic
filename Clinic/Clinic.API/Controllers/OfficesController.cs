using Clinic.API.Models;
using Clinic.API.Models.Office;
using Clinic.Application.Commands.Office.Create;
using Clinic.Application.Commands.Office.Delete;
using Clinic.Application.Commands.Office.Update;
using Clinic.Application.Queries.Office.GetByCity;
using Clinic.Application.Queries.Office.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Clinic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfficesController : ControllerBase
{
    private readonly IMediator _mediator;

    public OfficesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetOfficeByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        var result = await _mediator.Send(
            new GetOfficeByIdInput(id),
            cancellationToken
        );

        if (result.Office is null)
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
            new OfficeResponse(result.Office)
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

    [HttpGet("city/{cityName}")]
    public async Task<ActionResult> GetOfficesByCityAsync(
        string cityName, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        var result = await _mediator.Send(
            new GetOfficesByCityInput(cityName),
            cancellationToken
        );

        var response = Ok(
            result.Offices.Select(o => new OfficeResponse(o))    
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
    public async Task<ActionResult> CreateOfficeAsync(
        OfficeCreationRequest request, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        var result = await _mediator.Send(
            new CreateOfficeInput(
                request.CityName,
                request.RegistryPhoneNumber
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

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOfficeRegistryPhoneNumberAsync(
        Guid id, OfficeUpdateRegistryPhoneNumberRequest request, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        await _mediator.Send(
            new UpdateOfficeInput(id, request.RegistryPhoneNumber),
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
    public async Task<ActionResult> DeleteOfficeAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        await _mediator.Send(
            new DeleteOfficeInput(id),
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
