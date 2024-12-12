using CustomsManagement.Application.Constants;
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
        if (request.Id <= 0)
        {
            throw new ApplicationException(ExceptionMessages.InvalidShipmentId);
        }

        if (string.IsNullOrEmpty(request.Status))
        {
            throw new ApplicationException(ExceptionMessages.InvalidShipmentStatus);
        }

        var shipment = await _shipmentRepository.GetByIdAsync(request.Id);
        if (shipment == null)
        {
            throw new ApplicationException(ExceptionMessages.ShipmentNotFound);
        }

        shipment.UpdateStatus(request.Status);

        await _shipmentRepository.UpdateAsync(shipment);

        return shipment.Id;
    }
}