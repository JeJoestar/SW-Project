// <copyright file="CloneController.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

#nullable disable
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SW.DAL;

namespace SW.WebAPI.Controllers
{
    [Route("api/clone")]
    [ApiController]
    public class CloneController : Controller
    {
        private readonly IMediator _mediator;
        public CloneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public class Filter
        {
            public int LegionId { get; set; }
            public int BaseId { get; set; }
        }

        [HttpGet]
        public async Task<IActionResult> GetClones(
            Filter filter, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var clones = await _mediator.Send(new GetClonesPageQuerry
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
            });
            return Ok(clones);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClone(int id)
        {
            var clone = await _mediator.Send(new GetCloneByIdQuerry { CloneId = id });
            return clone is null ? NotFound() : Ok(clone);
        }

        [HttpPost]
        public async Task<IActionResult> InsertClone([FromBody] CloneDto clone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(new InsertCloneCommand()
            {
                CloneDto = clone,
            });
           return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCloneCommand() { CloneId = id });
            return Ok(result);
        } 
    }
}
