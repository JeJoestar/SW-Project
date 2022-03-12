// <copyright file="JediController.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SW.DAL;


namespace SW.WebAPI.Controllers
{
    [Route("api/jedi")]
    [ApiController]
    public class JediController : Controller
    {
        private readonly IMediator _mediator;

        public JediController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJedi(int id)
        {
            var jediDto = await _mediator.Send(new GetJediByIdQuerry { JediId = id });
            return Ok(jediDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJedi(JediDto jedi)
        {
            var result = await _mediator.Send(new InsertJediCommand { Jedi = jedi });
            return Ok(result);
        }
    }
}
