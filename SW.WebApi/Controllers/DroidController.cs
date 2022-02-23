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
            Expression<Func<Droid, bool>> filter = null)
        {
            var droids = await _mediator.Send(filter);
            return Ok(droids);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var droid = await _mediator.Send(new GetDroidByIdQuerry { DroidId = id });
            if (droid is null)
            {
                return NotFound();
            }
            DroidDTO returnClone = new ()
            {
                Model = droid.Model,
                BaseId = droid.BaseId,
                StarshipId = droid.StarshipId,
                Equipment = droid.Equipment
            };
            return Ok(returnClone);
        } 
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DroidDTO droid)
        {
            var result = await _mediator.Send(new InsertDroidCommand()
            {
                Droid = new Droid()
                {
                    Model = droid.Model,
                    BaseId = droid.BaseId,
                    StarshipId = droid.StarshipId,
                    Equipment = droid.Equipment
                }
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
