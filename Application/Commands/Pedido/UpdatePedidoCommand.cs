using Application.Responses.Pedido;
using MediatR;

namespace Application.Commands.Pedido;

public class UpdatePedidoCommand : IRequest<UpdatePedidoResponse>
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public bool Pago { get; set; }
}