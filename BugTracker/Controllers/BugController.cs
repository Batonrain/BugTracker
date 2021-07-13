using System.Threading.Tasks;
using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BugController : Controller
	{
		private readonly IBugService _bugService;

		public BugController(IBugService bugService)
		{
			_bugService = bugService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _bugService.GetAll();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(long id)
		{
			var result = await _bugService.Get(id);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpGet("byFilters")]
		public async Task<IActionResult> Get(string name, string description, int? status)
		{
			var result = await _bugService.Get(name, description, status);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateBugModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return Ok(new {id = await _bugService.Add(model)});
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody]UpdateBugModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			if (!(await _bugService.IsExists(id)))
			{
				return NotFound();
			}

			await _bugService.Update(id, model);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (!(await _bugService.IsExists(id)))
			{
				return NotFound();
			}

			await _bugService.Delete(id);

			return Ok();
		}
	}
}