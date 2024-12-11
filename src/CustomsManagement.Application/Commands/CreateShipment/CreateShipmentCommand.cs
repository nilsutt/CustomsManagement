using CustomsManagement.Domain.Constants;
using MediatR;

namespace CustomsManagement.Application.Commands.CreateShipment;

public class CreateShipmentCommand : IRequest<int>
{
    public string ImporterExporterName { get; set; }
    public ProductType ProductType { get; set; }
    public decimal DeclaredValue { get; set; }
}