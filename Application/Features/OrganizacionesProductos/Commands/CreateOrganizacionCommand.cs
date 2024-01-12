using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrganizacionesProductos.Commands
{
    public class CreateOrganizacionCommand : IRequest<int>
    {
        //public int IdOrganizacion { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public string SitioWeb { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

        public override string ToString()
        {
            return $"Organizacion nombre: {Nombre}, Pais: {Pais}, ";
        }
    }
}
