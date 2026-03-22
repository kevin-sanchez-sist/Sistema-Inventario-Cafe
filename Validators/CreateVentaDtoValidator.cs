using FluentValidation;

public class CreateVentaDtoValidator : AbstractValidator<CreateVentaDto>
{
    public CreateVentaDtoValidator()
    {
        RuleFor(x => x.VendedorId)
            .NotNull()
            .WithMessage("El vendedor es obligatorio.");

        RuleFor(x => x.Items)
            .NotNull()
            .WithMessage("La venta debe tener al menos un producto.");

        RuleForEach(x => x.Items)
            .ChildRules(item =>
            {
                item.RuleFor(x => x.ProductoId)
                    .NotNull()
                    .WithMessage("El producto es obligatorio.");

                item.RuleFor(x => x.Cantidad)
                    .GreaterThan(0)
                    .WithMessage("La cantidad debe ser mayor a cero.");
            });
    }
}