using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrganizacionesProductos.Commands
{
    public class CreateOrganizacionCommandValidator : AbstractValidator<CreateOrganizacionCommand>
    {

        public CreateOrganizacionCommandValidator()
        {
            RuleFor(x => x.Nombre)
                   .NotEmpty()
                   .WithMessage("Nombre Producto Requerido");

            RuleFor(x => x.Pais)
                   .NotEmpty()
                   .WithMessage("Pais Requerido");

            RuleFor(x => x.SitioWeb)
                   .NotEmpty()
                   .WithMessage("SitioWeb Requerido");

            RuleFor(x => x.Direccion)
                  .NotEmpty()
                  .WithMessage("Direccion Requerido");

            RuleFor(x => x.email)
                .NotEmpty()
                .WithMessage("email Requerido");


        }

    }
}
