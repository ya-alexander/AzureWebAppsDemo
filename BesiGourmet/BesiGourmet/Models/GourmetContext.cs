using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.Models
{
    public class GourmetContext : DbContext
    {
        public GourmetContext(DbContextOptions<GourmetContext> options) : base(options) {

        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuNotification> MenuNotifications { get; set; }
        public DbSet<MenuOrder> MenuOrders { get; set; }
    }
}
