using CustomsManagement.Application.DTOs;
using CustomsManagement.Domain.Entities.Aggregates;
using CustomsManagement.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomsManagement.Application.Queries.GetShipments;

public class GetShipmentsQueryHandler : IRequestHandler<GetShipmentsQuery, List<ShipmentDto>>
{
    private readonly IRepository<Shipment> _shipmentRepository;

    public GetShipmentsQueryHandler(IRepository<Shipment> shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<List<ShipmentDto>> Handle(GetShipmentsQuery request, CancellationToken cancellationToken)
    {
        var shipments = _shipmentRepository.TableNoTracking;

        if (!string.IsNullOrEmpty(request.Status)) // update status process
        {
            shipments = shipments.Where(s => s.Status == request.Status);
        }
        
        if (request.DelayedDayCount.HasValue)
        {
            var currentDate = DateTime.UtcNow;
            shipments = shipments.Where(s => (currentDate - s.CreatedDate).TotalDays >= request.DelayedDayCount.Value);
        }
        
        return await shipments.Select(s => new ShipmentDto
        {
            Id = s.Id,
            ImporterExporterName = s.ImporterExporterName,
            ProductType = s.ProductType.ToString(),
            DeclaredValue = s.DeclaredValue,
            Tax = s.Tax,
            Status = s.Status,
            CreatedDate = s.CreatedDate
        }).ToListAsync();
    }
}