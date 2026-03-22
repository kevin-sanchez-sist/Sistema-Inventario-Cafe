using FluentValidation;

public class UpdateUsuarioDtoValidator : AbstractValidator<UpdateUsuarioDto>
{
    public UpdateUsuarioDtoValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("El formato de correo electronico ingresado no es válido.")
            .When(x => x.Email != null);

        RuleFor(x => x.Password)
            .MinimumLength(8)
            .WithMessage("La contraseña debe tener al menos 8 caracteres.")
            .Matches(@"[A-Z]+")
            .WithMessage("La contraseña debe contener al menos una letra mayúscula.")
            .Matches(@"[a-z]+")
            .WithMessage("La contraseña debe contener al menos una letra minúscula.")
            .Matches(@"\d+")
            .WithMessage("La contraseña debe contener al menos un número.")
            .When(x => x.Password != null);
    }
}