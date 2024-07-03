using Clinic.API.Models;
using Clinic.API.Models.Office;
using Clinic.Application.Commands.Office.Create;
using Clinic.Application.Commands.Office.Delete;
using Clinic.Application.Commands.Office.Update;
using Clinic.Application.Queries.Office.GetByCity;
using Clinic.Application.Queries.Office.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        var result = await _mediator.Send(
            new GetOfficeByIdInput(id),
            cancellationToken
        );

        if (result.Office is null)
            return NotFound();

        return Ok(
            new OfficeResponse(result.Office)
        );
    }

    [HttpGet("city/{cityName}")]
    public async Task<ActionResult> GetOfficesByCityAsync(
        string cityName, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new GetOfficesByCityInput(cityName),
            cancellationToken
        );

        return Ok(
            result.Offices.Select(o => new OfficeResponse(o))    
        );
    }

    [HttpPost]
    public async Task<ActionResult> CreateOfficeAsync(
        OfficeCreationRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new CreateOfficeInput(
                request.CityName,
                request.RegistryPhoneNumber
            ),
            cancellationToken
        );
        return Ok(
            new CreatedEntityResponse(result.Id)    
        );

    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOfficeRegistryPhoneNumberAsync(
        Guid id, OfficeUpdateRegistryPhoneNumberRequest request, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new UpdateOfficeInput(id, request.RegistryPhoneNumber),
            cancellationToken
        );

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOfficeAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new DeleteOfficeInput(id),
            cancellationToken
        );

        return NoContent();
    }
}
