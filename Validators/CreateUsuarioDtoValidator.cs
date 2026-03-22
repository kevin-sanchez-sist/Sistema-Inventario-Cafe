using FluentValidation;
using ProyectoInventario.models;

public class CreateUsuarioDtoValidator : AbstractValidator<CreateUsuarioDto>
{
    public CreateUsuarioDtoValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty()
            .WithMessage("Ingresa un nombre valido, no puede ser vacio.");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El correo electronico es obligatorio.")
            .EmailAddress()
            .WithMessage("El formato de correo electronico ingresado no es válido.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es obligatoria.")
            .MinimumLength(8)
            .WithMessage("La contraseña debe tener al menos 8 caracteres.")
            .Matches(@"[A-Z]+")
            .WithMessage("La contraseña debe contener al menos una letra mayúscula.")
            .Matches(@"[a-z]+")
            .WithMessage("La contraseña debe contener al menos una letra minúscula.")
            .Matches(@"\d+")
            .WithMessage("La contraseña debe contener al menos un número.");

        RuleFor(x => x.Rol)
            .IsInEnum()
            .WithMessage("Seleccione un rol de usuario valido.");

            
    }
        
}