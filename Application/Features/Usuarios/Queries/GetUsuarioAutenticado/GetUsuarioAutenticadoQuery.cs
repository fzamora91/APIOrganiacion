using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Queries.GetUsuarioAutenticado
{
    public class GetUsuarioAutenticadoQuery : IRequest<UsuarioAutenticadoVm>
    {
        public string usuario;
        public string clave;
    }
}
