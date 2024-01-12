﻿using Application.Features.Productos.Commands;
using Application.Features.Productos.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    public class ProductoController : ApiControllerBase
    {
        [HttpGet]
        public async Task<List<ProductosListVM>> Get()
        {
            return await Mediator.Send(new GetProductosListQuery());
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductoCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}