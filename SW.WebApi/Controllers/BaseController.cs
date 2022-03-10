// <copyright file="BaseController.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SW.DAL;

namespace SW.WebAPI.Controllers
{
    [Route("api/base")]
    [ApiController]
    public class BaseController : Controller
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBase(int id)
        {
            var basee = await _mediator.Send(new GetBaseByIdQuerry { BaseId = id });
            return basee is null ? NotFound() : Ok(basee);
        }
    }
}
