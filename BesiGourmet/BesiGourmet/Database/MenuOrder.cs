using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.Database
{
    public class MenuOrder
    {
		public Guid Id { get; set; }

		public Guid MenuId { get; set; }

		public Menu Menu { get; set; }

		public Guid AadUserId { get; set; }

		public DateTime OrderDate { get; set; }

		public DateTime DateOfConsumption { get; set; }	
	}
}
