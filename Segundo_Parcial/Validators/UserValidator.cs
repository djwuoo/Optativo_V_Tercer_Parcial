using FluentValidation;
using Segundo_Parcial.Models;

namespace Segundo_Parcial.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MinimumLength(3).WithMessage("El apellido debe tener al menos 3 caracteres.");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Length(10).WithMessage("El teléfono debe tener 10 dígitos.")
                .Matches(@"^\d+$").WithMessage("El teléfono debe ser numérico.");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("El documento es obligatorio.")
                .MinimumLength(7).WithMessage("El documento debe tener al menos 7 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("El correo electrónico debe tener un formato válido.");

            RuleFor(x => x.Estado)
                .Equal("Activo").WithMessage("El estado debe ser 'Activo' para obtener los datos del cliente.");
        }
    }
}
