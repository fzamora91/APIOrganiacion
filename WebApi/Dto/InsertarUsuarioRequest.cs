﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class InsertarUsuarioRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public bool activo { get; set; }
        public DateTime Ultima_sesion { get; set; }
    }
}
