using Application.Responses.Pedido;
using AutoMapper;
using Domain.Contracts.Repository;
using MediatR;

namespace Application.Commands.Pedido.Handlers;

public class CreatePedidoHandler : IRequestHandler<CreatePedidoCommand, CreatePedidoResponse>
{
    private readonly IMapper _mapper;
    
    private readonly IPedidoRepository _pedidoRepository;

    public CreatePedidoHandler(
        IPedidoRepository pedidoRepository, 
        IMapper mapper)
    {
        _pedidoRepository = pedidoRepository;
        _mapper = mapper;
    }

    public async Task<CreatePedidoResponse> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = _mapper.Map<Domain.Models.Pedido>(request);

        pedido.DataCriacao = DateTime.Now;
        
        var savedPedido = await _pedidoRepository.Create(pedido);
        
        return _mapper.Map<CreatePedidoResponse>(savedPedido);
    }
}