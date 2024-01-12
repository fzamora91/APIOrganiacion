using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Productos.Commands
{
    public class DeleteProductoCommandValidator : AbstractValidator<DeleteProductoCommand>
    {
        public DeleteProductoCommandValidator()
        {
            RuleFor(x => x.IdProducto)
                   .NotEmpty()
                   .WithMessage("{PropertyName} Requerido");



        }
    }
}
