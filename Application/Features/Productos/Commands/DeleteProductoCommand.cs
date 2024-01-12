using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Productos.Commands
{
    public class DeleteProductoCommand: IRequest<int>
    {
        public int IdProducto { get; set; }

    }
}
