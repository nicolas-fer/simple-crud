using Application.Responses.Pedido;
using AutoMapper;
using Domain.Contracts.Repository;
using MediatR;

namespace Application.Commands.Pedido.Handlers;

public class DeletePedidoHandler : IRequestHandler<DeletePedidoCommand, DeletePedidoResponse>
{
    private readonly IMapper _mapper;
    
    private readonly IPedidoRepository _pedidoRepository;

    public DeletePedidoHandler(IPedidoRepository pedidoRepository, IMapper mapper)
    {
        _pedidoRepository = pedidoRepository;
        _mapper = mapper;
    }

    public async Task<DeletePedidoResponse> Handle(DeletePedidoCommand request, CancellationToken cancellationToken)
    {
        var pedidoValidacao = await _pedidoRepository.GetById(request.Id);

        if (pedidoValidacao is null)
            throw new ApplicationValidationException("Pedido não encontrado!", "Pedido não encontrado na base de dados!");
        
        await _pedidoRepository.Delete(request.Id);
        
        return new DeletePedidoResponse();
    }
}