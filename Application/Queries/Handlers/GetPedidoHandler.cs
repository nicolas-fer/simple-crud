using Application.Responses.Pedido;
using Domain.Contracts.Repository;
using MediatR;

namespace Application.Queries.Handlers;

public class GetPedidoHandler : IRequestHandler<GetPedidoQuery, GetPedidoResponse>
{
    private readonly IPedidoRepository _pedidoRepository;

    public GetPedidoHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<GetPedidoResponse> Handle(GetPedidoQuery request, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.GetById(request.Id);

        if (pedido is null)
            throw new ApplicationValidationException("Pedido não encontrado!", "Pedido não encontrado na base de dados!");

        return new GetPedidoResponse()
        {
            Id = pedido.Id,
            NomeCliente = pedido.NomeCliente,
            EmailCliente = pedido.EmailCliente,
            Pago = pedido.Pago,
            ValorTotal = pedido.ItensPedidos?.Sum(x => (x.Produto?.Valor ?? 0) * x.Quantidade) ?? 0,
            ItensPedido = pedido.ItensPedidos?.Select(ip => new GetPedidoResponse.Item
            {
                Id = ip.Id,
                IdProduto = ip.Produto?.Id ?? 0,
                NomeProduto = ip.Produto?.NomeProduto ?? string.Empty,
                ValorUnitario = ip.Produto?.Valor ?? 0,
                Quantidade = ip.Quantidade
            }).ToList() ?? new List<GetPedidoResponse.Item>()
        };
    }
}