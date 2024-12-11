using CustomsManagement.Application.Commands.CreateShipment;
using CustomsManagement.Application.Commands.DeleteShipment;
using CustomsManagement.Application.Commands.UpdateShipmentStatus;
using CustomsManagement.Application.Queries.GetShipment;
using CustomsManagement.Application.Queries.GetShipments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomsManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShipmentController(
        IMediator mediator
    ) =>
        _mediator = mediator;

    [HttpPost("create")]
    public async Task<IActionResult> CreateShipment([FromBody] CreateShipmentCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetShipment), new { id = result }, result);
    }

    [HttpPut("update-status")]
    public async Task<IActionResult> UpdateShipmentStatus([FromBody] UpdateShipmentStatusCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetShipment), new { id = result }, result);
    }

    [HttpGet("get-shipment")]
    public async Task<IActionResult> GetShipment([FromQuery] int id)
    {
        var query = new GetShipmentQuery
        {
            Id = id,
        };

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("get-shipments")]
    public async Task<IActionResult> GetShipments([FromQuery] string? status, [FromQuery] int? delayedDayCount)
    {
        var query = new GetShipmentsQuery
        {
            Status = status,
            DelayedDayCount = delayedDayCount
        };

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteShipment([FromBody] DeleteShipmentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}