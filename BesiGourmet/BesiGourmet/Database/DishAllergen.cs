using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.Database
{
	public class DishAllergen
	{
		public Guid Id { get; set; }

		public Guid AllergenId { get; set; }

		public Allergen Allergen { get; set; }

		public Guid DishId { get; set; }

		public Dish Dish { get; set; }
	}
}
