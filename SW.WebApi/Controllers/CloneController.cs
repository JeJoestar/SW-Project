// <copyright file="CloneController.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

#nullable disable
using System.Linq.Expressions;
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

        [HttpGet]
        public async Task<IActionResult> GetClones(
            Expression<Func<Clone, bool>> filter = null)
        {
            var clones = await _mediator.Send(filter);
            return Ok(clones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClone(int id)
        {
            var clone = await _mediator.Send(new GetCloneByIdQuerry { CloneId = id });
            if (clone is null)
            {
                return NotFound();
            }
            CloneDTO returnClone = new ()
            {
                Number = clone.Number,
                LegionId = clone.LegionId,
                BaseId = clone.BaseId,
                StarshipId = clone.StarshipId,
                Equipment = clone.Equipment,
                Qualification = clone.Qualification
            };
            return Ok(returnClone);
        } 

        [HttpPost]
        public async Task<IActionResult> InsertClone([FromBody] CloneDTO clone)
        {
            var result = await _mediator.Send(new InsertCloneCommand()
            {
                Clone = new Clone()
                {
                    Number = clone.Number,
                    LegionId = clone.LegionId,
                    BaseId = clone.BaseId,
                    StarshipId = clone.StarshipId,
                    Equipment = clone.Equipment,
                    Qualification = clone.Qualification,
                }
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
