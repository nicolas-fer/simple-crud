using FluentValidation;

namespace Application.Commands.Pedido.Validators;

public class DeletePedidoCommandValidator : AbstractValidator<DeletePedidoCommand>
{
    public DeletePedidoCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().Must(x => x > 0).WithMessage("Insira um id válido");
    }
}