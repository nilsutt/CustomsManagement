using CustomsManagement.Application.DTOs;
using MediatR;

namespace CustomsManagement.Application.Queries.GetShipments;

public class GetShipmentsQuery : IRequest<List<ShipmentDto>>
{
    public string Status { get; set; } // Optional filter for shipment status
    public int? DelayedDayCount { get; set; } // Optional filter for creation date
}