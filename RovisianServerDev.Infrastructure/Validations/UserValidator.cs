using FluentValidation;
using RovisianServerDev.Application.DTOs;

namespace RovisianServerDev.Infrastructure.Validations
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(entity=> entity.Cedula).NotNull();
            RuleFor(entity => entity.Nombre).NotNull();
            RuleFor(entity => entity.Apellidos).NotNull();
            RuleFor(entity => entity.Correo).NotNull();
            RuleFor(entity => entity.Contrasenna).NotNull();
            //RuleFor(entity => entity.Firma).NotNull();
        }
    }
}
