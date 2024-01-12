using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Commands
{
    public class DeleteUsuariosCommandValidator:AbstractValidator<DeleteUsuariosCommand>
    {
        public DeleteUsuariosCommandValidator()
        {
            RuleFor(x => x.IdUsuario)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido");

           


        }
    }
}
