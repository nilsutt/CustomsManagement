using CustomsManagement.Application.Constants;
using CustomsManagement.Application.DTOs;
using CustomsManagement.Application.Extentions;
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
        if (request.Id <= 0)
        {
            throw new ApplicationException(ExceptionMessages.InvalidShipmentId);
        }

        var shipment = await _shipmentRepository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (shipment == null)
        {
            throw new ApplicationException(ExceptionMessages.ShipmentNotFound);
        }

        return new ShipmentDto
        {
            Id = shipment.Id,
            ImporterExporterName = shipment.ImporterExporterName,
            ProductType = shipment.ProductType.GetDisplayName(), 
            DeclaredValue = shipment.DeclaredValue,
            Tax = shipment.Tax,
            Status = shipment.Status,
            CreatedDate = shipment.CreatedDate
        };
    }
    
}