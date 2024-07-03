using Clinic.API.Models;
using Clinic.API.Models.Receptionist;
using Clinic.Application.Commands.Receptionist.Create;
using Clinic.Application.Commands.Receptionist.Delete;
using Clinic.Application.Queries.Receptionist.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
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
        var result = await _mediator.Send(
            new GetReceptionistByIdInput(id),
            cancellationToken
        );

        if (result.Receptionist is null)
            return NotFound();

        return Ok(
            result.Receptionist    
        );
    }

    [HttpPost]
    public async Task<ActionResult> CreateReceptionistAsync(
        ReceptionistCreationRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new CreateReceptionistInput(
                request.Email,
                request.Password,
                request.PhoneNumber,
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.OfficeId
            ),
            cancellationToken
        );

        return Ok(
            new CreatedEntityResponse(result.Id)    
        );
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteReceptionistAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new DeleteReceptionistInput(id),
            cancellationToken
        );

        return NoContent();
    }
}
