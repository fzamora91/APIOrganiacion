﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrganizacionesProductos.Commands
{
    public class DeleteOrganizacionCommand: IRequest
    {
        public int IdOrganizacion { get; set; }
    }
}