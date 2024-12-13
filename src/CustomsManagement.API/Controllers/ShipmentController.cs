using CustomsManagement.Application.Commands.CreateShipment;
using CustomsManagement.Application.Commands.DeleteShipment;
using CustomsManagement.Application.Commands.UpdateShipment;
using CustomsManagement.Application.Commands.UpdateShipmentStatus;
using CustomsManagement.Application.Constants;
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
        if (command == null)
        {
            return BadRequest(ExceptionMessages.InvalidRequest);
        }

        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetShipment), new { id = result }, result);
    }

    [HttpPut("update-status")]
    public async Task<IActionResult> UpdateShipmentStatus([FromBody] UpdateShipmentStatusCommand command)
    {
        if (command == null || command.Id <= 0 || string.IsNullOrEmpty(command.Status))
        {
            return BadRequest(ExceptionMessages.InvalidRequest);
        }

        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateShipment([FromBody] UpdateShipmentCommand command)
    {
        if (command == null || command.Id <= 0)
        {
            return BadRequest("Invalid request");
        }

        try
        {
            var result = await _mediator.Send(command);
            return Ok(new { Id = result });
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-shipment")]
    public async Task<IActionResult> GetShipment([FromQuery] int id)
    {
        if (id <= 0)
        {
            return BadRequest(ExceptionMessages.InvalidShipmentId);
        }

        var query = new GetShipmentQuery { Id = id };

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("get-shipments")]
    public async Task<IActionResult> GetShipments([FromQuery] string? status, [FromQuery] int? delayedDayCount)
    {
        if (delayedDayCount.HasValue && delayedDayCount.Value <= 0)
        {
            return BadRequest(ExceptionMessages.InvalidDelayedDayCount);
        }

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
        if (command == null || command.Id <= 0)
        {
            return BadRequest(ExceptionMessages.InvalidShipmentId);
        }

        await _mediator.Send(command);
        return NoContent();
    }
}