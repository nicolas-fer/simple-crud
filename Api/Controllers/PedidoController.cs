using Application.Commands.Pedido;
using Application.Queries;
using Application.Responses.Pedido;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TesteStef.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IMediator _mediator;

    public PedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<CreatePedidoResponse> CreateAsync([FromBody] CreatePedidoCommand? command)
    {
        var response = await _mediator.Send(command ?? new CreatePedidoCommand());

        return response;
    }
    
    [HttpPut]
    public async Task<UpdatePedidoResponse> UpdateAsync([FromBody] UpdatePedidoCommand? command)
    {
        var response = await _mediator.Send(command ?? new UpdatePedidoCommand());

        return response;
    }
    
    [HttpDelete]
    public async Task<DeletePedidoResponse> DeleteAsync([FromBody] DeletePedidoCommand? command)
    {
        var response = await _mediator.Send(command ?? new DeletePedidoCommand());

        return response;
    }
    
    [HttpGet]
    public async Task<GetPedidoResponse> GetAsync([FromQuery] int? id)
    {
        var response = await _mediator.Send(id == null ? new GetPedidoQuery() : new GetPedidoQuery{Id = id.Value});

        return response;
    }
}