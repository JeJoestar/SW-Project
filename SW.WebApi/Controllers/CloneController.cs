﻿#nullable disable
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
        public async Task<IActionResult> Get(
            Expression<Func<Clone, bool>> filter = null)
        {
            var clones = await _mediator.Send(filter);
            return Ok(clones);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var clone = await _mediator.Send(new GetCloneById { Id = id });
            return Ok(clone);
        } 
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]Clone clone)
        {
           var result = await _mediator.Send(new InsertClone() { Clone = clone});
           return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var clone = await _mediator.Send(new DeleteClone() { Id = id });
            return Ok(clone);
        }
        
    }
}
