using MediatR;

namespace CustomsManagement.Application.Commands.UpdateShipmentStatus;

public class UpdateShipmentStatusCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Status { get; set; }
}