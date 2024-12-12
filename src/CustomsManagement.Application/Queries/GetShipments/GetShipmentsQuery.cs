using CustomsManagement.Application.DTOs;
using MediatR;

namespace CustomsManagement.Application.Queries.GetShipments;

public class GetShipmentsQuery : IRequest<List<ShipmentDto>>
{
    public string Status { get; set; }
    public int? DelayedDayCount { get; set; }
}