using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrganizacionesProductos.Commands
{
    public class DeleteOrganizacionCommandValidator : AbstractValidator<DeleteOrganizacionCommand>
    {
        public DeleteOrganizacionCommandValidator()
        {
            RuleFor(x => x.IdOrganizacion)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido");
        }

    }
}
