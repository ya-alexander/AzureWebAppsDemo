using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.Database
{
    public class MenuPlan
    {
		#region update

		public Guid Id { get; set; }

		public Guid Menu1Id { get; set; }

		public Menu Menu1 { get; set; }

		public Guid Menu2Id { get; set; }

		public Menu Menu2 { get; set; }

		public DateTime Date { get; set; }
		
		#endregion
	}
}
