using CustomsManagement.Application.Constants;
using CustomsManagement.Application.DTOs;
using CustomsManagement.Application.Extentions;
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
        if (request.DelayedDayCount.HasValue && request.DelayedDayCount.Value <= 0)
        {
            throw new ApplicationException(ValidationMessages.DelayedDayCountPositive);
        }

        var shipments = _shipmentRepository.TableNoTracking;

        if (shipments == null || !shipments.Any())
        {
            throw new ApplicationException(ExceptionMessages.NoShipmentsAvailable);
        }

        if (!string.IsNullOrEmpty(request.Status))
        {
            shipments = shipments.Where(s => s.Status == request.Status);
        }

        if (request.DelayedDayCount.HasValue)
        {
            var currentDate = DateTime.UtcNow;
            shipments = shipments.Where(s => (currentDate - s.CreatedDate).TotalDays >= request.DelayedDayCount.Value);
        }

        var result = await shipments.Select(s => new ShipmentDto
        {
            Id = s.Id,
            ImporterExporterName = s.ImporterExporterName,
            ProductType = s.ProductType.GetDisplayName(),
            DeclaredValue = s.DeclaredValue,
            Tax = s.Tax,
            Status = s.Status,
            CreatedDate = s.CreatedDate
        }).ToListAsync();

        if (result == null || !result.Any())
        {
            throw new ApplicationException(ExceptionMessages.NoShipmentsAvailable);
        }

        return result;
    }
    
}