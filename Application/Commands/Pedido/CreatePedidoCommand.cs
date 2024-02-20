using Application.Responses.Pedido;
using MediatR;

namespace Application.Commands.Pedido;

public class CreatePedidoCommand : IRequest<CreatePedidoResponse>
{
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public bool Pago { get; set; }
}