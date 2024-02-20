using FluentValidation;

namespace Application.Queries.Validators;

public class GetPedidoQueryValidator : AbstractValidator<GetPedidoQuery>
{
    public GetPedidoQueryValidator()
    {
        RuleFor(x => x.Id).NotNull().Must(x => x > 0).WithMessage("Insira um id válido");
    }
}