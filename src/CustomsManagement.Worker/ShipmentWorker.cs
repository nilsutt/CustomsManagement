using CustomsManagement.Application.Commands.UpdateShipmentStatus;
using CustomsManagement.Application.Services;
using CustomsManagement.Domain.Constants;
using MediatR;

namespace CustomsManagement.Worker;

public class ShipmentWorker : BackgroundService
{
    private readonly ILogger<ShipmentWorker> _logger;
    private readonly ShipmentService _shipmentService;
    private readonly IMediator _mediator;

    public ShipmentWorker(ILogger<ShipmentWorker> logger, ShipmentService shipmentService, IMediator mediator)
    {
        _logger = logger;
        _shipmentService = shipmentService;
        _mediator = mediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("ShipmentWorker running at: {time}", DateTimeOffset.Now);
                }
                
                var delayedShipments = await _shipmentService.GetDelayedShipmentsAsync();

                foreach (var shipment in delayedShipments)
                {
                    await _mediator.Send(new UpdateShipmentStatusCommand
                    {
                        Id = shipment.Id,
                        Status = ShipmentStatus.Delayed
                    }, stoppingToken);
                }

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Processed {count} delayed shipments.", delayedShipments.Count);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing delayed shipments.");
            }
            
            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }
}