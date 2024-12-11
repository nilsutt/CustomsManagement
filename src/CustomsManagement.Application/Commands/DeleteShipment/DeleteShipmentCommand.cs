using CustomsManagement.Domain.Constants;
using MediatR;

namespace CustomsManagement.Application.Commands.DeleteShipment;

public class DeleteShipmentCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteShipmentCommand(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be greater than zero.", nameof(id));
        }
        Id = id;
    }
}