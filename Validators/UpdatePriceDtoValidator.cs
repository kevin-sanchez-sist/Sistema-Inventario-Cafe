using FluentValidation;

public class UpdatePriceDtoValidator : AbstractValidator<UpdatePriceDto>
{
    public UpdatePriceDtoValidator()
    {
        RuleFor(x => x.Precio)
            .GreaterThan(0)
            .WithMessage("El precio debe ser mayor a cero.")
            .When(x => x.Precio != null);
    }
}