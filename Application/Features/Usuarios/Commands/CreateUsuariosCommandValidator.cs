using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Commands
{
    public class CreateUsuariosCommandValidator : AbstractValidator<CreateUsuariosCommand>
    {

        public CreateUsuariosCommandValidator()
        {
            RuleFor(x => x.Nombre)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.Apellido)
                  .NotEmpty()
                  .WithMessage("{PropertyName} Requerido");


            RuleFor(x => x.telefono)
                  .NotEmpty()
                  .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.email)
                 .NotEmpty()
                 .WithMessage("{PropertyName} Requerido");

        }

    }
}
