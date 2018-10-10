using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.Database
{
    public class Menu
    {
		public Guid Id { get; set; }

		public Dish Starter { get; set; }

		public Guid StarterId { get; set; }

		public Dish MainCourse { get; set; }

		public Guid MainCourseId { get; set; }

		public Dish Desert { get; set; }

		public Guid DesertId { get; set; }
	}
}
