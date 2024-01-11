using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Commands
{
    public class CreateUsuariosCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public bool activo { get; set; }
        public DateTime Ultima_sesion { get; set; }

        public override string ToString()
        {
            return $"Usuario nombre: {Nombre}, Apellido: {Apellido},   ";
        }

    }
}
