using Application.Responses.Pedido;
using AutoMapper;
using Domain.Contracts.Repository;
using MediatR;

namespace Application.Commands.Pedido.Handlers;

public class UpdatePedidoHandler : IRequestHandler<UpdatePedidoCommand, UpdatePedidoResponse>
{
    private readonly IMapper _mapper;
    
    private readonly IPedidoRepository _pedidoRepository;

    public UpdatePedidoHandler(IMapper mapper, IPedidoRepository pedidoRepository)
    {
        _mapper = mapper;
        _pedidoRepository = pedidoRepository;
    }

    public async Task<UpdatePedidoResponse> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
    {
        var pedidoValidacao = await _pedidoRepository.GetById(request.Id);

        if (pedidoValidacao is null)
            throw new ApplicationValidationException("Pedido não encontrado!", "Pedido não encontrado na base de dados!");
        
        var pedido = _mapper.Map<Domain.Models.Pedido>(request);
        
        var updatedPedido = await _pedidoRepository.Update(pedido);
        
        return _mapper.Map<UpdatePedidoResponse>(updatedPedido);
    }
}