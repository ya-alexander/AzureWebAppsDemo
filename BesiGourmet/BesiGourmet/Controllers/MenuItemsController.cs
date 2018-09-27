using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BesiGourmet.Models;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace BesiGourmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly GourmetContext _context;

        public MenuItemsController(GourmetContext context)
        {
            _context = context;
            _context.MenuItems.Add(new MenuItem() { Name = "Schnitzel", Date = DateTime.Now });
            _context.MenuItems.Add(new MenuItem() { Name = "Pizza", Date = new DateTime(2018, 10, 1) });
            _context.MenuItems.Add(new MenuItem() { Name = "Salat", Date = new DateTime(2018, 10, 2) });

            _context.SaveChanges();
        }

        // GET: api/MenuItems
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<MenuItem> GetMenuItems()
        {
            return _context.MenuItems;
        }
    }
}