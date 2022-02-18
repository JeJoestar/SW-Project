#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SW.DAL;

namespace SW.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloneController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public CloneController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var clone = await _mediator.Send(new Clone { Id = id });
            return Ok(clone);
        } 
       
    }
}
