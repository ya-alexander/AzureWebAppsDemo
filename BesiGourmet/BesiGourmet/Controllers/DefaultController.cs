using BesiGourmet.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace BesiGourmet.Controllers
{
	/// <summary>
	/// A class that provides access to the web api
	/// </summary>
	[Authorize]
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		private readonly DatabaseContext _context;
		private readonly TelemetryClient _telemetry;

		public DefaultController(DatabaseContext context, TelemetryClient telemetry)
		{
			_context = context;
			_telemetry = telemetry;
		}

		#region menu
		/// <summary>
		/// Get menus
		/// </summary>
		/// <returns></returns>
		[HttpGet("menu")]
		[ProducesResponseType(typeof(Menu), 200)]
		public ActionResult<Menu> GetMenu()
		{
			var menus = _context.Menu.Include<Menu>("Starter")
				.Include<Menu, Dish>(x => x.Starter)
				.Include<Menu, Dish>(x => x.MainCourse)
				.Include<Menu, Dish>(x => x.Desert);

			try
			{
				throw new Exception("Foo");
			}
			catch (Exception e)
			{
				_telemetry.TrackException(new ExceptionTelemetry { Exception = e });
			}

			return Ok(menus);
		}
		#endregion

		#region dishes
		/// <summary>
		/// Get dishes
		/// </summary>
		/// <returns></returns>
		[HttpGet("dish")]
		[ProducesResponseType(typeof(Dish), 200)]
		public ActionResult<Dish> GetDish()
		{
			var dishes = _context.Dish;
			return Ok(dishes);
		}

		/// <summary>
		/// Add dish
		/// </summary>
		/// <returns></returns>
		[HttpPut("dish")]
		[ProducesResponseType(typeof(Dish), 200)]
		public ActionResult<Dish> AddMenu([FromBody] Dish dish)
		{
			_context.Dish.Add(dish);
			_context.SaveChanges();

			return NoContent();
		}
		#endregion

		#region menuplan
		/// <summary>
		/// Get menu plan for a given start date
		/// </summary>
		/// <returns></returns>
		[HttpGet("menuplan/{date}")]
		[ProducesResponseType(typeof(MenuPlan), 200)]
		public ActionResult<MenuPlan> GetMenuPlan([FromRoute] DateTime date)
		{
			var menuPlan = _context.MenuPlan.Where(x => x.Date == date)
				.Include("Menu1.Starter")
				.Include("Menu1.MainCourse")
				.Include("Menu1.Desert")
				.Include("Menu2.Starter")
				.Include("Menu2.MainCourse")
				.Include("Menu2.Desert");
			return Ok(menuPlan);
		}
		#endregion

		#region menuorder

		[HttpGet("menuorder/{date}")]
		[ProducesResponseType(typeof(MenuOrder), 200)]
		public ActionResult<MenuOrder> GetMenuOrder([FromRoute] DateTime date)
		{
			var menuOrder = _context.MenuOrder.Where(x => x.DateOfConsumption == date)
				.Include("Menu.Starter")
				.Include("Menu.MainCourse")
				.Include("Menu.Desert");
			return Ok(menuOrder);
		}

		[HttpGet("menuorder/missing/{date}/{userId}")]
		[ProducesResponseType(typeof(MenuOrder), 200)]
		public ActionResult<MenuOrder> MissingMenuOrder([FromRoute] DateTime date, [FromRoute] Guid userId)
		{
			var menuOrder = _context.MenuOrder.SingleOrDefault(x => x.DateOfConsumption == date && x.AadUserId == userId);
			if (menuOrder == null)
			{
				return Ok(new MenuOrder());
			}
			else
			{
				return Ok(menuOrder);
			}
		}

		[HttpPut("menuorder")]
		[ProducesResponseType(typeof(MenuOrder), 200)]
		public ActionResult<MenuOrder> AddMenuOrder([FromBody] MenuOrder order)
		{
			using (var operation = _telemetry.StartOperation<RequestTelemetry>("AddMenuOrder"))
			{
				_telemetry.TrackTrace("Parsing payload...");
				_context.MenuOrder.Add(order);
				_telemetry.TrackTrace("Added order to set...");
				_context.SaveChanges();
				_telemetry.TrackTrace("Saved changes to db...");
			}

			return NoContent();
		}

		#endregion
	}
}