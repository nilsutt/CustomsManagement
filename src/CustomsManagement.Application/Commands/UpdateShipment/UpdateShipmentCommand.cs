using MediatR;

namespace CustomsManagement.Application.Commands.UpdateShipment;

public class UpdateShipmentCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string ImporterExporterName { get; set; }
    public int ProductTypeId { get; set; } 
    public decimal DeclaredValue { get; set; }
    public string Status { get; set; }
}