using CustomsManagement.Domain.Entities.Aggregates;
using CustomsManagement.Domain.Interfaces;
using MediatR;

namespace CustomsManagement.Application.Commands.UpdateShipmentStatus;

public class UpdateShipmentStatusCommandHandler : IRequestHandler<UpdateShipmentStatusCommand, int>
{
    private readonly IRepository<Shipment> _shipmentRepository;

    public UpdateShipmentStatusCommandHandler(IRepository<Shipment> shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<int> Handle(UpdateShipmentStatusCommand request, CancellationToken cancellationToken)
    {
        var shipment = await _shipmentRepository.GetByIdAsync(request.Id);
        if (shipment == null)
        {
            throw new ArgumentException(nameof(UpdateShipmentStatusCommand));
        }
        
        shipment.UpdateStatus(request.Status);

        await _shipmentRepository.UpdateAsync(shipment);
        
        return shipment.Id;
    }
}