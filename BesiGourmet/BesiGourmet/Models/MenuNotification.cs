using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.Models
{
    public class MenuNotification
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public MenuItem Item{ get; set; }
    }
}
