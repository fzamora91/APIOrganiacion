using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Queries
{
    public class GetUsuariosListQuery : IRequest<List<UsuariosListVM>>
    {

    }
}
