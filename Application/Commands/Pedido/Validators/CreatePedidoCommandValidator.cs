using FluentValidation;

namespace Application.Commands.Pedido.Validators;

public class CreatePedidoCommandValidator : AbstractValidator<CreatePedidoCommand>
{
    public CreatePedidoCommandValidator()
    {
        RuleFor(x => x.EmailCliente).NotEmpty().MaximumLength(60);
        RuleFor(x => x.NomeCliente).NotEmpty().MaximumLength(60);
        RuleFor(x => x.Pago).NotEmpty();
    }
}