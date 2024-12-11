using CustomsManagement.Domain.Constants;
using CustomsManagement.Domain.Entities.Aggregates;
using CustomsManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomsManagement.Application.Services;

public class ShipmentService
{
    private readonly IRepository<Shipment> _shipmentRepository;

    public ShipmentService(IRepository<Shipment> shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<List<Shipment>> GetDelayedShipmentsAsync()
    {
        var cutoffDate = DateTime.UtcNow.AddDays(-3);
        return await _shipmentRepository.TableNoTracking
            .Where(s => s.Status == ShipmentStatus.Pending && s.CreatedDate <= cutoffDate)
            .ToListAsync();
    }
}
