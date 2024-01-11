using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Productos.Queries
{
    public class GetProductosListQuery : IRequest<List<ProductosListVM>>
    {
    }
}
