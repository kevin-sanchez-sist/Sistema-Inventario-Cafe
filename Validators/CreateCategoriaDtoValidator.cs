using FluentValidation;

public class CreateCategoriaDtoValidator : AbstractValidator<CreateCategoriaDto>
{
    public CreateCategoriaDtoValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty()
            .WithMessage("El nombre de la categoria no puede estar vacio.")
            .MinimumLength(3)
            .WithMessage("El nombre de la categoria debe tener una longitud de al menos 3 caracteres.")
            .MaximumLength(15)
            .WithMessage("El nombre de la categoria debe tener una longitud de máximo 15 caracteres.");
    }
}