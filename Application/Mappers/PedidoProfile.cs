using Application.Commands.Pedido;
using Application.Responses.Pedido;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<CreatePedidoCommand, Pedido>()
            .ReverseMap();
        CreateMap<CreatePedidoResponse, Pedido>()
            .ReverseMap();
        
        CreateMap<UpdatePedidoCommand, Pedido>()
            .ReverseMap();
        CreateMap<UpdatePedidoResponse, Pedido>()
            .ReverseMap();
    }
}