using Application.Responses.Pedido;
using MediatR;

namespace Application.Commands.Pedido;

public class DeletePedidoCommand : IRequest<DeletePedidoResponse>
{
    public int Id { get; set; }
}