using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.Organizacion
{
    public class ActualizarOrganizacionRequest
    {
        public int IdOrganizacion { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public string SitioWeb { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}
