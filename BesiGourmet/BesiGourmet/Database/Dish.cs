using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.Database
{
    public class Dish
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public bool IsVegeterian { get; set; }

		public List<DishAllergen> DishAllergens { get; set; }
	}
}
