﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrganizacionesProductos.Commands
{
    public class UpdateOrganizacionCommandValidator : AbstractValidator<UpdateOrganizacionCommand>
    {

        public UpdateOrganizacionCommandValidator()
        {
            RuleFor(x => x.IdOrganizacion)
                 .NotEmpty()
                 .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.Nombre)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.Pais)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.SitioWeb)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.Direccion)
                  .NotEmpty()
                  .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.email)
                .NotEmpty()
                .WithMessage("{PropertyName} Requerido");


        }

    }
}
