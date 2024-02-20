using FluentValidation;

namespace Application.Commands.Pedido.Validators;

public class UpdatePedidoCommandValidator : AbstractValidator<UpdatePedidoCommand>
{
    public UpdatePedidoCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().Must(x => x > 0).WithMessage("Insira um id válido");
        RuleFor(x => x.EmailCliente).NotEmpty().MaximumLength(60).EmailAddress();
        RuleFor(x => x.NomeCliente).NotEmpty().MaximumLength(60);
        RuleFor(x => x.Pago).NotEmpty();
    }
}