#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var droid = await _mediator.Send(new GetDroidById { Id = id });
            if (droid is null)
                return NotFound();
            DroidDTO returnClone = new()
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
            var result = await _mediator.Send(new InsertDroid()
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
            var result = await _mediator.Send(new DeleteDroid() { Id = id });
            return Ok(result);
        }
        
    }
}
