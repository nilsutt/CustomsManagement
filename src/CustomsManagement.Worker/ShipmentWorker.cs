using MediatR;
using CustomsManagement.Application.Commands.UpdateShipmentStatus;
using CustomsManagement.Application.Queries.GetShipments;

namespace CustomsManagement.Worker;

public class ShipmentWorker : BackgroundService
{
    private readonly ILogger<ShipmentWorker> _logger;
    private readonly IMediator _mediator;

    public ShipmentWorker(ILogger<ShipmentWorker> logger, IMediator mediator)
    {
        _logger = logger;
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
                
                var delayedShipments = await _mediator.Send(new GetShipmentsQuery
                {
                    Status = "Pending",
                    DelayedDayCount = 3 
                }, stoppingToken);

                foreach (var shipment in delayedShipments)
                {
                    await _mediator.Send(new UpdateShipmentStatusCommand
                    {
                        Id = shipment.Id,
                        Status = "Delayed"
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
