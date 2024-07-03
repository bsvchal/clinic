using Clinic.API.Models;
using Clinic.API.Models.Photo;
using Clinic.Application.Commands.Photo.Create;
using Clinic.Application.Commands.Photo.Delete;
using Clinic.Application.Commands.Photo.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        var result = await _mediator.Send(
            new CreatePhotoInput(request.Path, request.AccountId),
            cancellationToken
        );

        return Ok(
            new CreatedEntityResponse(result.Id)
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePhotoAsync(
        Guid id, PhotoUpdatePathRequest request, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new UpdatePhotoInput(id, request.Path),
            cancellationToken
        );

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePhotoAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new DeletePhotoInput(id),
            cancellationToken
        );

        return NoContent();
    }
}
