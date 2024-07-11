using Clinic.API.Models;
using Clinic.API.Models.Photo;
using Clinic.Application.Commands.Photo.Create;
using Clinic.Application.Commands.Photo.Delete;
using Clinic.Application.Commands.Photo.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Clinic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhotosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PhotosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePhotoAsync(
        PhotoCreationRequest request, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        var result = await _mediator.Send(
            new CreatePhotoInput(request.Path, request.AccountId),
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
    public async Task<ActionResult> UpdatePhotoAsync(
        Guid id, PhotoUpdatePathRequest request, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        await _mediator.Send(
            new UpdatePhotoInput(id, request.Path),
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
    public async Task<ActionResult> DeletePhotoAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var start = DateTime.Now;
        await _mediator.Send(
            new DeletePhotoInput(id),
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
