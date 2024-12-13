using CustomsManagement.Domain.Constants;
using CustomsManagement.Domain.Entities.Aggregates;
using CustomsManagement.Domain.Interfaces;
using MediatR;

namespace CustomsManagement.Application.Commands.UpdateShipment;

public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand, Unit>
{
    private readonly IRepository<Shipment> _shipmentRepository;

    public UpdateShipmentCommandHandler(IRepository<Shipment> shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<Unit> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
    {
        if (!Enum.IsDefined(typeof(ProductType), request.ProductTypeId))
        {
            throw new ApplicationException("Invalid Product Type ID");
        }

        var productType = (ProductType)request.ProductTypeId;

        var shipment = await _shipmentRepository.GetByIdAsync(request.Id);
        if (shipment == null)
        {
            throw new ApplicationException("Shipment not found");
        }

        shipment.UpdateDetails(request.ImporterExporterName, productType, request.DeclaredValue, request.Status);
        await _shipmentRepository.UpdateAsync(shipment);

        return Unit.Value;
    }

}