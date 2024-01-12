﻿using Application.Features.OrganizacionesUsuarios.Commands;
using Application.Features.OrganizacionesUsuarios.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Dto;

namespace WebApi.Areas
{
    [Authorize]
    public class OrganizacionController : ApiControllerBase
    {

        // GET
        /*[HttpGet]
        public async Task<List<OrganizacionesListVM>> Get()
        {
            return await Mediator.Send(new GetOrganizacionesListQuery());
        }*/

        //POST
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] InsertarOrganizacionRequest dto)
        {
            
            CreateOrganizacionCommand command = new CreateOrganizacionCommand();
            return await Mediator.Send(command);
        }
    }
}
