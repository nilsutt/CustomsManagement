using MediatR;
using CustomsManagement.Application.Commands.UpdateShipmentStatus;
using CustomsManagement.Application.Queries.GetShipments;
using CustomsManagement.Domain.Constants;

namespace CustomsManagement.Worker;

public class ShipmentWorker : BackgroundService
{
    private readonly ILogger<ShipmentWorker> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ShipmentWorker(ILogger<ShipmentWorker> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceScopeFactory.CreateScope();

                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("ShipmentWorker running at: {time}", DateTimeOffset.Now);
                }

                var delayedShipments = await mediator.Send(new GetShipmentsQuery
                {
                    Status = ShipmentStatus.Pending,
                    DelayedDayCount = ShipmentConstants.DelayedDayThreshold
                }, stoppingToken);

                foreach (var shipment in delayedShipments)
                {
                    await mediator.Send(new UpdateShipmentStatusCommand
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
