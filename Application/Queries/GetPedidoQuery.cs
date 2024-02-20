using Application.Responses.Pedido;
using MediatR;

namespace Application.Queries;

public class GetPedidoQuery : IRequest<GetPedidoResponse>
{
    public int Id { get; set; }   
}