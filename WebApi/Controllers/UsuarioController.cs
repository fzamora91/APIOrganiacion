﻿using Application.Features.Usuarios.Commands;
using Application.Features.Usuarios.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    public class UsuarioController : ApiControllerBase
    {

        [HttpGet]
        public async Task<List<UsuariosListVM>> Get()
        {
            return await Mediator.Send(new GetUsuariosListQuery());
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateUsuariosCommand command)
        {
            return await Mediator.Send(command);
        }


        
    }
}