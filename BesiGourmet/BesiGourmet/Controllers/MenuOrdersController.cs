using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BesiGourmet.Models;

namespace BesiGourmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuOrdersController : ControllerBase
    {
        private readonly GourmetContext _context;

        public MenuOrdersController(GourmetContext context)
        {
            _context = context;
        }

        // POST: api/MenuOrders
        [HttpPost]
        public async Task<IActionResult> OrderMenu([FromBody] MenuOrder menuOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MenuOrders.Add(menuOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuOrder", new { id = menuOrder.Id }, menuOrder);
        }
    }
}