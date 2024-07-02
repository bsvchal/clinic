using Clinic.Application.Commands.Office.Create;
using Clinic.Application.Queries.Office.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public async Task<GetOfficeByIdOutput> GetOfficeByIdAsync(Guid id)
    {
        var response = await _mediator.Send(new GetOfficeByIdInput(id));
        return response;
    }

    [HttpPost]
    public async Task<CreateOfficeOutput> CreateOfficeAsync(
        CreateOfficeInput request)
    {
        var response = await _mediator.Send(
            new CreateOfficeInput(
                request.CityName, request.RegistryPhoneNumber
            )
        );
        return response;
    }
}
