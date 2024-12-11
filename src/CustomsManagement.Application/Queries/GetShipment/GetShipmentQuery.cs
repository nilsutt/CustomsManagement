using CustomsManagement.Application.DTOs;
using MediatR;

namespace CustomsManagement.Application.Queries.GetShipment;

public class GetShipmentQuery : IRequest<ShipmentDto>
{
    public int Id { get; set; }
}