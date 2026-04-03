using FluentValidation;

public class CreateProveedorDtoValidator : AbstractValidator<CreateProveedorDto>
{
    public CreateProveedorDtoValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty()
            .WithMessage("El nombre del proveedor es obligatorio.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El email del proveedor es obligatorio.")
            .EmailAddress()
            .WithMessage("El formato de email no es válido.");

        RuleFor(x => x.Telefono)
            .NotEmpty()
            .WithMessage("El teléfono es obligatorio.")
            .Matches(@"^\+?[\d\s\-]{7,15}$")
            .WithMessage("El formato de teléfono no es válido.");

        RuleFor(x => x.Ciudad)
            .NotEmpty()
            .WithMessage("La ciudad es obligatoria.");
    }
}