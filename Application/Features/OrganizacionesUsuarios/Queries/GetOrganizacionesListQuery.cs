﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrganizacionesUsuarios.Queries
{
    public class GetOrganizacionesListQuery : IRequest<List<OrganizacionesListVM>>
    {

    }
}
