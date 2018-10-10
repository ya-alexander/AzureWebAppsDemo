using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.Database
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{

		}

		public DbSet<Menu> Menu { get; set; }

		public DbSet<Allergen> Allergen { get; set; }

		public DbSet<Dish> Dish { get; set; }

		public DbSet<MenuOrder> MenuOrder { get; set; }

		public DbSet<MissingMenuOrderReminder> MissingMenuOrder { get; set; }

		public DbSet<MenuPlan> MenuPlan { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DishAllergen>()
				.HasKey(bc => new { bc.DishId, bc.AllergenId });

			modelBuilder.Entity<DishAllergen>()
				.HasOne(bc => bc.Dish)
				.WithMany(b => b.DishAllergens)
				.HasForeignKey(bc => bc.DishId);

			modelBuilder.Entity<DishAllergen>()
				.HasOne(bc => bc.Allergen)
				.WithMany(c => c.DishAllergens)
				.HasForeignKey(bc => bc.AllergenId);

			modelBuilder.Entity<Menu>()
				.HasOne(b => b.Starter)
				.WithMany()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Menu>()
				.HasOne(b => b.MainCourse)
				.WithMany()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Menu>()
				.HasOne(b => b.Desert)
				.WithMany()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<MenuPlan>()
				.HasOne(b => b.Menu1)
				.WithMany()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<MenuPlan>()
				.HasOne(b => b.Menu2)
				.WithMany()
				.OnDelete(DeleteBehavior.Restrict);

			this.SeedData(modelBuilder);
		}

		private void SeedData(ModelBuilder modelBuilder)
		{
			#region allergens
			var a = new Allergen { Id = Guid.Parse("b8671bad-d096-4a06-b0fb-c7bbe8bdaa35"), Code = "A", Description = "Glutenhaltiges Getreide und daraus gewonnene Erzeugnisse" };
			var b = new Allergen { Id = Guid.Parse("f1ef4b1f-af99-4fa8-9793-ce1a34c96e95"), Code = "B", Description = "Krebstiere und daraus gewonnene Erzeugnisse" };
			var c = new Allergen { Id = Guid.Parse("84a90738-c08f-415d-8819-790e1683aa60"), Code = "C", Description = "Eier von Geflügel und daraus gewonnene Erzeugnisse" };
			var d = new Allergen { Id = Guid.Parse("17567a74-a17b-41eb-b1d9-b77b59613bba"), Code = "D", Description = "Fisch und daraus gewonnene Erzeugnisse (ausser Fischgelatine)" };
			var e = new Allergen { Id = Guid.Parse("1b3d8e5e-8d83-443a-b923-6ff1e0ab4b3e"), Code = "E", Description = "Erdnüsse und daraus gewonnene Erzeugnisse" };

			var allergens = new[] { a, b, c, d, e, };
			#endregion

			#region dishes
			// starters
			var dish6 = new Dish { Id = Guid.Parse("ea26695e-32ab-4d0a-aa63-2a2fd1d845a6"), Title = "Fritattensuppe", IsVegeterian = false };
			var dish7 = new Dish { Id = Guid.Parse("71aeb877-d026-4b2f-a285-3ab25ce8079d"), Title = "Grüner Salat", IsVegeterian = false };
			var dish8 = new Dish { Id = Guid.Parse("db1a947a-1316-490f-a13c-21049c2a47ec"), Title = "Kürbiscremesuppe", IsVegeterian = false };

			// mains
			var dish1 = new Dish { Id = Guid.Parse("f2cbbd62-50ee-441d-a426-10adf2e7702d"), Title = "Schnitzel mit Reis", IsVegeterian = false };
			var dish2 = new Dish { Id = Guid.Parse("2c0eda9c-a8d2-4003-aa1e-4cefec42a525"), Title = "Kaiserschmarrn mit Zwetschkenröster", IsVegeterian = true };
			var dish3 = new Dish { Id = Guid.Parse("ac3aeeb9-8e15-424f-ab3c-b76c81c7ed2c"), Title = "Currypfanne mit Fisch", IsVegeterian = false };
			var dish4 = new Dish { Id = Guid.Parse("3245fad8-7e2c-4f35-a927-142143970911"), Title = "Gebackene Champions", IsVegeterian = true };
			var dish5 = new Dish { Id = Guid.Parse("be302ff1-a6e0-471f-a481-f52cf6e00c53"), Title = "Backhendl mit Vogerlsalat", IsVegeterian = false };

			// desert
			var dish9 = new Dish { Id = Guid.Parse("c8a7d53c-e2a1-4aa2-a82b-cca7f91d340a"), Title = "Gemischtes Eis", IsVegeterian = true };
			var dish10 = new Dish { Id = Guid.Parse("c10a9afb-48bd-420f-8994-36bffb55601d"), Title = "Vanillepudding", IsVegeterian = true };
			var dish11 = new Dish { Id = Guid.Parse("a0bff874-1181-416c-99c7-f169098bce68"), Title = "Käseplatte mit Weintrauben", IsVegeterian = true };

			var dishes = new[] { dish6, dish7, dish8, dish1, dish2, dish3, dish4, dish5, dish9, dish10, dish11 };
			#endregion

			#region dishAllergens
			var dish6Allergen1 = new DishAllergen { DishId = dish6.Id, AllergenId = a.Id };
			var dish6Allergen2 = new DishAllergen { DishId = dish6.Id, AllergenId = b.Id };

			var dish7Allergen1 = new DishAllergen { DishId = dish7.Id, AllergenId = a.Id };

			var dish8Allergen1 = new DishAllergen { DishId = dish8.Id, AllergenId = a.Id };
			var dish8Allergen2 = new DishAllergen { DishId = dish8.Id, AllergenId = b.Id };

			var dish1Allergen1 = new DishAllergen { DishId = dish1.Id, AllergenId = b.Id };
			var dish1Allergen2 = new DishAllergen { DishId = dish1.Id, AllergenId = d.Id };
			var dish1Allergen3 = new DishAllergen { DishId = dish1.Id, AllergenId = a.Id };

			var dish2Allergen1 = new DishAllergen { DishId = dish2.Id, AllergenId = c.Id };
			var dish2Allergen2 = new DishAllergen { DishId = dish2.Id, AllergenId = d.Id };
			var dish2Allergen3 = new DishAllergen { DishId = dish2.Id, AllergenId = a.Id };

			var dish3Allergen1 = new DishAllergen { DishId = dish3.Id, AllergenId = d.Id };
			var dish3Allergen2 = new DishAllergen { DishId = dish3.Id, AllergenId = b.Id };
			var dish3Allergen3 = new DishAllergen { DishId = dish3.Id, AllergenId = e.Id };

			var dish4Allergen1 = new DishAllergen { DishId = dish4.Id, AllergenId = d.Id };
			var dish4Allergen2 = new DishAllergen { DishId = dish4.Id, AllergenId = e.Id };

			var dish5Allergen1 = new DishAllergen { DishId = dish5.Id, AllergenId = a.Id };
			var dish5Allergen2 = new DishAllergen { DishId = dish5.Id, AllergenId = b.Id };
			var dish5Allergen3 = new DishAllergen { DishId = dish5.Id, AllergenId = c.Id };
			var dish5Allergen4 = new DishAllergen { DishId = dish5.Id, AllergenId = d.Id };
			var dish5Allergen5 = new DishAllergen { DishId = dish5.Id, AllergenId = e.Id };

			var dishAllergens = new[] { dish6Allergen1, dish6Allergen2, dish7Allergen1, dish8Allergen1, dish8Allergen2 };
			#endregion

			#region menus
			// starters
			var menu1 = new Menu { Id = Guid.Parse("b05db3a3-3a73-4a77-8d14-edcf5c97c26e"), StarterId = dish6.Id, MainCourseId = dish1.Id, DesertId = dish9.Id };
			var menu2 = new Menu { Id = Guid.Parse("4cbec5f7-508f-4f09-96a7-2a5f69e63a10"), StarterId = dish7.Id, MainCourseId = dish2.Id, DesertId = dish10.Id };
			var menu3 = new Menu { Id = Guid.Parse("3bd04bdc-9b34-4e3f-984f-c9bdef93eb31"), StarterId = dish8.Id, MainCourseId = dish3.Id, DesertId = dish11.Id };
			var menu4 = new Menu { Id = Guid.Parse("d495f77c-5818-4217-aded-d3afa7884ed8"), StarterId = dish8.Id, MainCourseId = dish4.Id, DesertId = dish9.Id };
			var menu5 = new Menu { Id = Guid.Parse("c7be0a47-0022-4504-8eb0-e81ce39287a8"), StarterId = dish7.Id, MainCourseId = dish5.Id, DesertId = dish11.Id };
			var menu6 = new Menu { Id = Guid.Parse("b1ad2b15-bd8c-44b1-9961-ced0c864857b"), StarterId = dish6.Id, MainCourseId = dish4.Id, DesertId = dish10.Id };
			var menu7 = new Menu { Id = Guid.Parse("c1de3bfc-cad7-45e4-a876-ab91c40121a1"), StarterId = dish7.Id, MainCourseId = dish3.Id, DesertId = dish10.Id };
			var menu8 = new Menu { Id = Guid.Parse("6e116e17-6dcc-4fe2-9195-4e5bb25d84ef"), StarterId = dish6.Id, MainCourseId = dish2.Id, DesertId = dish11.Id };
			var menu9 = new Menu { Id = Guid.Parse("d2fed096-ca8c-4586-914e-b71a1674c607"), StarterId = dish8.Id, MainCourseId = dish1.Id, DesertId = dish9.Id };

			var menus = new[] { menu1, menu2, menu3, menu4, menu5, menu6, menu7, menu8, menu9 };
			#endregion

			#region menuplan

			var menuplanMonday1 = new MenuPlan { Id = Guid.Parse("2fcdec11-75a8-46f8-a863-0c09edbda186"), Date = new DateTime(2018, 10, 1), Menu1Id = menu1.Id, Menu2Id = menu2.Id };
			var menuplanTuesday1 = new MenuPlan { Id = Guid.Parse("1e1242d0-a506-495b-bb8a-6fe975fa16da"), Date = new DateTime(2018, 10, 2), Menu1Id = menu2.Id, Menu2Id = menu3.Id };
			var menuplanWednesday1 = new MenuPlan { Id = Guid.Parse("3f6bc956-a055-4d4a-b420-33aa1027861c"), Date = new DateTime(2018, 10, 3), Menu1Id = menu3.Id, Menu2Id = menu4.Id };
			var menuplanThursday1 = new MenuPlan { Id = Guid.Parse("480f9569-6252-446e-a1f7-3a4a15242a13"), Date = new DateTime(2018, 10, 4), Menu1Id = menu4.Id, Menu2Id = menu5.Id };
			var menuplanFriday1 = new MenuPlan { Id = Guid.Parse("e56a47cb-9db6-4827-b488-5ea836743a7b"), Date = new DateTime(2018, 10, 5), Menu1Id = menu5.Id, Menu2Id = menu6.Id };

			var menuplanMonday2 = new MenuPlan { Id = Guid.Parse("240c50c2-c209-4e99-b493-5391bf51e6d7"), Date = new DateTime(2018, 10, 8), Menu1Id = menu3.Id, Menu2Id = menu4.Id };
			var menuplanTuesday2 = new MenuPlan { Id = Guid.Parse("f4d29af4-a070-498c-bd49-4ea9e1c862c9"), Date = new DateTime(2018, 10, 9), Menu1Id = menu4.Id, Menu2Id = menu5.Id };
			var menuplanWednesday2 = new MenuPlan { Id = Guid.Parse("f36dd6bc-baef-4690-8800-2b6137d88261"), Date = new DateTime(2018, 10, 10), Menu1Id = menu5.Id, Menu2Id = menu6.Id };
			var menuplanThursday2 = new MenuPlan { Id = Guid.Parse("9a54335c-55a4-4a5e-80f9-9e458af86121"), Date = new DateTime(2018, 10, 11), Menu1Id = menu6.Id, Menu2Id = menu7.Id };
			var menuplanFriday2 = new MenuPlan { Id = Guid.Parse("7ac61fe9-eb6c-4d00-8bf9-d84b880f735f"), Date = new DateTime(2018, 10, 12), Menu1Id = menu7.Id, Menu2Id = menu8.Id };

			var menuplanMonday3 = new MenuPlan { Id = Guid.Parse("71a3b6e6-15a2-49b5-8349-d07a0c80afb9"), Date = new DateTime(2018, 10, 15), Menu1Id = menu5.Id, Menu2Id = menu6.Id };
			var menuplanTuesday3 = new MenuPlan { Id = Guid.Parse("32223c3c-7be1-4183-9e16-c1d066367f27"), Date = new DateTime(2018, 10, 16), Menu1Id = menu6.Id, Menu2Id = menu7.Id };
			var menuplanWednesday3 = new MenuPlan { Id = Guid.Parse("81e2ed71-a46d-4586-909a-b5102ce3231f"), Date = new DateTime(2018, 10, 17), Menu1Id = menu7.Id, Menu2Id = menu8.Id };
			var menuplanThursday3 = new MenuPlan { Id = Guid.Parse("ffec2e49-5031-44cb-b58f-0eb527137e78"), Date = new DateTime(2018, 10, 18), Menu1Id = menu8.Id, Menu2Id = menu9.Id };
			var menuplanFriday3 = new MenuPlan { Id = Guid.Parse("4e57187f-bc86-4db2-9f10-a6a226dfc23e"), Date = new DateTime(2018, 10, 19), Menu1Id = menu9.Id, Menu2Id = menu1.Id };

			var menuplans = new[] { menuplanMonday1, menuplanTuesday1, menuplanWednesday1, menuplanThursday1, menuplanFriday1, menuplanMonday2, menuplanTuesday2, menuplanWednesday2, menuplanThursday2, menuplanFriday2, menuplanMonday3, menuplanTuesday3, menuplanWednesday3, menuplanThursday3, menuplanFriday3 };

			#endregion

			var menuOrder = new MenuOrder { Id = Guid.Parse("0051b968-3c49-4412-ae87-c4b31cc1b1ad"), OrderDate = DateTime.Today, DateOfConsumption = new DateTime(2018, 10, 4), MenuId = Guid.Parse("b05db3a3-3a73-4a77-8d14-edcf5c97c26e"), AadUserId = Guid.Parse("9273e08c-1f0c-4580-ac9c-009b4367fb84") };

			var menuOrders = new[] { menuOrder };

			modelBuilder.Entity<Allergen>().HasData(allergens);
			modelBuilder.Entity<Dish>().HasData(dishes);
			modelBuilder.Entity<DishAllergen>().HasData(dishAllergens);
			modelBuilder.Entity<Menu>().HasData(menus);
			modelBuilder.Entity<MenuPlan>().HasData(menuplans);
			modelBuilder.Entity<MenuOrder>().HasData(menuOrders);
		}
	}
}
