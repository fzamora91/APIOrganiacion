﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Commands
{
    public class DeleteUsuariosCommand:IRequest<int>
    {
        public int IdUsuario { get; set; }

    }
}
