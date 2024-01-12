using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDeailQuery:IRequest<UsuarioDetailVM>
    {
        public int id;
    }
}
