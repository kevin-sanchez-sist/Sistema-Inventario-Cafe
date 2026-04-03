using FluentValidation;

public class UpdateProveedorDtoValidator : AbstractValidator<UpdateProveedorDto>
{
    public UpdateProveedorDtoValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("El formato de email no es válido.")
            .When(x => x.Email != null);

        RuleFor(x => x.Telefono)
            .Matches(@"^\+?[\d\s\-]{7,15}$")
            .WithMessage("El formato de teléfono no es válido.")
            .When(x => x.Telefono != null);

        RuleFor(x => x.Ciudad)
            .NotEmpty()
            .WithMessage("La ciudad no puede estar vacía.")
            .When(x => x.Ciudad != null);
    }
}