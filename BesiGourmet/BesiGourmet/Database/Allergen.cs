using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.Database
{
    public class Allergen
    {
		public Guid Id { get; set; }

		public string Code { get; set; }

		public string Description { get; set; }

		public List<DishAllergen> DishAllergens { get; set; }
	}
}
