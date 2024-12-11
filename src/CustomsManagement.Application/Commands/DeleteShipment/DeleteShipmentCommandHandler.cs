using CustomsManagement.Domain.Entities.Aggregates;
using CustomsManagement.Domain.Interfaces;
using MediatR;

namespace CustomsManagement.Application.Commands.DeleteShipment;

public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, Unit>
{
    private readonly IRepository<Shipment> _shipmentRepository;

    public DeleteShipmentCommandHandler(IRepository<Shipment> shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<Unit> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
    {
        var shipment = await _shipmentRepository.GetByIdAsync(request.Id);

        if (shipment == null)
        {
            throw new KeyNotFoundException($"Shipment with Id {request.Id} not found.");
        }

        shipment.MarkAsDeleted();
        await _shipmentRepository.UpdateAsync(shipment);

        return Unit.Value;
    }

}