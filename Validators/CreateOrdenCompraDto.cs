using FluentValidation;

public class CreateOrdenCompraDtoValidator : AbstractValidator<CreateOrdenCompraDto>
{
    public CreateOrdenCompraDtoValidator()
    {
        RuleFor(x => x.ProveedorId)
            .NotNull()
            .WithMessage("El proveedor es obligatorio.");

        RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty()
            .WithMessage("La orden debe tener al menos un producto.");

        RuleForEach(x => x.Items)
            .ChildRules(item =>
            {
                item.RuleFor(x => x.ProductoId)
                    .NotNull()
                    .WithMessage("El producto es obligatorio.");

                item.RuleFor(x => x.Cantidad)
                    .NotNull()
                    .GreaterThan(0)
                    .WithMessage("La cantidad debe ser mayor a cero.");

                item.RuleFor(x => x.CostoUnitario)
                    .NotNull()
                    .GreaterThan(0)
                    .WithMessage("El costo unitario debe ser mayor a cero.");
            });
    }
}