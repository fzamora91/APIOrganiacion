using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Productos.Commands
{
    public class UpdateProductoCommandValidator : AbstractValidator<UpdateProductoCommand>
    {
        public UpdateProductoCommandValidator()
        {

            RuleFor(x => x.IdProducto)
                 .NotEmpty()
                 .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.Nombre_Producto)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.Precio)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido")
                   .GreaterThan(0);

            RuleFor(x => x.Creado_Por)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido");

            RuleFor(x => x.Modificado_Por)
                  .NotEmpty()
                  .WithMessage("{PropertyName} Requerido");


        }
    }
}
