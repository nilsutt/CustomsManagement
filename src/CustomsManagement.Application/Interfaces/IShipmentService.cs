using CustomsManagement.Domain.Entities.Aggregates;

namespace CustomsManagement.Application.Interfaces;

public interface IShipmentService
{
    Task<List<Shipment>> GetDelayedShipmentsAsync();
}