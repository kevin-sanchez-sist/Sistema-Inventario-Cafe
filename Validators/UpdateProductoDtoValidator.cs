using FluentValidation;

public class UpdateProductoDtoValidator : AbstractValidator<UpdateProductoDto>
{
    public UpdateProductoDtoValidator()
    {
        RuleFor(x => x.Precio)
            .GreaterThan(0)
            .WithMessage("El precio debe ser mayor a cero.")
            .When(x => x.Precio != null);

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El stock no puede ser negativo.")
            .When(x => x.Stock != null);

        RuleFor(x => x.Estado)
            .IsInEnum()
            .WithMessage("El estado del producto no es válido.")
            .When(x => x.Estado != null);
    }
}