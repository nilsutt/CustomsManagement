using CustomsManagement.Application.Constants;
using CustomsManagement.Domain.Constants;
using CustomsManagement.Domain.Entities.Aggregates;
using CustomsManagement.Domain.Interfaces;
using MediatR;

namespace CustomsManagement.Application.Commands.CreateShipment;

public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, int>
{
    private readonly IRepository<Shipment> _shipmentRepository;

    public CreateShipmentCommandHandler(IRepository<Shipment> shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<int> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.ImporterExporterName))
        {
            throw new ApplicationException(ExceptionMessages.ImporterExporterNameRequired);
        }

        if (!Enum.IsDefined(typeof(ProductType), request.ProductType))
        {
            throw new ApplicationException(ExceptionMessages.ProductTypeRequired);
        }

        if (request.DeclaredValue <= 0)
        {
            throw new ApplicationException(ExceptionMessages.InvalidDeclaredValue);
        }

        var shipment = new Shipment(
            request.ImporterExporterName,
            request.ProductType,
            request.DeclaredValue
        );

        await _shipmentRepository.AddAsync(shipment);
        return shipment.Id;
    }
}