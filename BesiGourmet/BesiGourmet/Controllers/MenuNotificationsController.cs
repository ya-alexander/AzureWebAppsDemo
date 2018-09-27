using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BesiGourmet.Models;
using Microsoft.AspNetCore.Authorization;

namespace BesiGourmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuNotificationsController : ControllerBase
    {
        private readonly GourmetContext _context;

        public MenuNotificationsController(GourmetContext context)
        {
            _context = context;

            _context.MenuNotifications.Add(new MenuNotification() { Email = "john.doe@example.com", Item = _context.MenuItems.FirstOrDefault() });
            _context.SaveChanges();
        }

        // GET: api/MenuNotifications
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<MenuNotification> GetMenuNotifications()
        {
            return _context.MenuNotifications;
        }

        // POST: api/MenuNotifications
        [HttpPost]
        public async Task<IActionResult> PostMenuNotification([FromBody] MenuNotification menuNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MenuNotifications.Add(menuNotification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuNotification", new { id = menuNotification.Id }, menuNotification);
        }
    }
}