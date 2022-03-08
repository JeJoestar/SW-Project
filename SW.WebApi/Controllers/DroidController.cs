// <copyright file="DroidController.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

#nullable disable
using System.Linq.Expressions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SW.DAL;

namespace SW.WebAPI.Controllers
{
    [Route("api/droid")]
    [ApiController]
    public class DroidController : Controller
    {
        private readonly IMediator _mediator;
        public DroidController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] int pageNumber, [FromQuery] int pageSize, Expression<Func<Droid, bool>> filter = null)
        {
            var droids = await _mediator.Send(new GetDroidsPageQuerry
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Filter = filter,
            });
            return Ok(droids);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var droid = await _mediator.Send(new GetDroidByIdQuerry { DroidId = id });
            return droid is null ? NotFound() : Ok(droid);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DroidDto droid)
        {
            var result = await _mediator.Send(new InsertDroidCommand()
            {
                DroidDto = droid,
            });
           return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDroidCommand() { DroidId = id });
            return Ok(result);
        }    
    }
}
