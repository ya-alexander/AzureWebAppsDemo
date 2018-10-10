using BesiGourmet.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BesiGourmet.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public async Task FetchMenus()
		{
			var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
			optionsBuilder.UseSqlServer("Server=tcp:besigourmet.database.windows.net,1433;Initial Catalog=BesiGourmet;Persist Security Info=False;User ID=besigourmet;Password=JqoPNratSCzR1HeRKOXX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
			var databaseContext = new DatabaseContext(optionsBuilder.Options);

			var menus = databaseContext.Menu;
			Assert.AreEqual(9, await menus.CountAsync());
		}
	}
}
