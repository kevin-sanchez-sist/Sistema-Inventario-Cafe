using System.Data;
using FluentValidation;
using ProyectoInventario.models;

public class CreateProductoDtoValidator : AbstractValidator<CreateProductoDto>
{
    public CreateProductoDtoValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty()
            .WithMessage("El nombre del producto no puede ser vacio");

        RuleFor(x => x.Precio)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El precio del producto no puede ser negativo.");

        RuleFor(x => x.CostoInicial)
            .NotNull()
            .WithMessage("El costo inicial del producto es obligatorio.")
            .GreaterThan(0)
            .WithMessage("El costo inicial debe ser mayor a cero.");
        
        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("La cantidad en stock no puede ser negativa.");

        RuleFor(x => x.Tipo)
            .IsInEnum()
            .WithMessage("Debe seleccionar un tipo de producto valida.");

        RuleFor(x => x.Sabor)
            .NotEmpty()
            .WithMessage("El producto dulce debe tener un sabor.")
            .When(x => x.Tipo == TipoProducto.ProductoDulce);
            
        
        RuleFor(x => x.Variante)
            .NotEmpty()
            .WithMessage("La variante del producto de cafe es obligatoria.")
            .When(x => x.Tipo == TipoProducto.ProductoCafe);
            

        RuleFor(x => x.EsMolido)
            .NotNull()
            .WithMessage("Debes indicar si el cafe es molido o no.")
            .When(x => x.Tipo == TipoProducto.ProductoCafe);
            
    }
}