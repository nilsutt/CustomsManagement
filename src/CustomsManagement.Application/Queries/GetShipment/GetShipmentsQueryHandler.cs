using CustomsManagement.Application.DTOs;
using CustomsManagement.Domain.Entities.Aggregates;
using CustomsManagement.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomsManagement.Application.Queries.GetShipment;

public class GetShipmentQueryHandler : IRequestHandler<GetShipmentQuery, ShipmentDto>
{
    private readonly IRepository<Shipment> _shipmentRepository;

    public GetShipmentQueryHandler(IRepository<Shipment> shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<ShipmentDto> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
    {
        var shipments = await _shipmentRepository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (shipments == null)
            throw new ArgumentNullException(nameof(shipments));

        var response = new ShipmentDto
        {
            Id = shipments.Id,
            ImporterExporterName = shipments.ImporterExporterName,
            ProductType = shipments.ProductType.ToString(),
            DeclaredValue = shipments.DeclaredValue,
            Tax = shipments.Tax,
            Status = shipments.Status,
            CreatedDate = shipments.CreatedDate
        };
        return response;
    }
}