using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Db;
using BugTracker.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Repositories
{
	public class BugRepository : IBugRepository
	{
		private readonly DataContext _context;

		public BugRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Bug>> GetAll()
		{
			return await _context.Bugs.ToListAsync();
		}

		public async Task<Bug> Get(long id)
		{
			return await _context.Bugs.FindAsync(id);
		}

		public async Task<IEnumerable<Bug>> Get(string name, string description, int? status)
		{
			var rawData = _context.Bugs.AsQueryable();

			if (status != null)
			{
				rawData = rawData.Where(bug => bug.Status == status);
			}

			if (!string.IsNullOrEmpty(name))
			{
				rawData = rawData.Where(bug => EF.Functions.Like(bug.Name, $"%{name}%"));
			}

			if (!string.IsNullOrEmpty(description))
			{
				rawData = rawData.Where(bug => EF.Functions.Like(bug.Name, $"%{description}%"));
			}

			return await rawData.ToListAsync();
		}

		public async Task<long> Add(Bug bug)
		{
			_context.Bugs.Add(bug);
			await _context.SaveChangesAsync();

			return bug.Id;
		}

		public async Task Update(Bug bug)
		{
			try
			{
				_context.Entry(bug).State = EntityState.Modified;

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException exception)
			{
				await exception.Entries.Single().ReloadAsync();
				await _context.SaveChangesAsync();
			}
		}

		public async Task Delete(long id)
		{
			try
			{
				var bug = await _context.Bugs.FirstOrDefaultAsync(b => b.Id == id);
				if (bug != null)
				{
					_context.Remove(bug);
				}

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException exception)
			{
				await exception.Entries.Single().ReloadAsync();
				await _context.SaveChangesAsync();
			}
		}

		public async Task<bool> IsExists(long id)
		{
			return await _context.Bugs.AnyAsync(bug => bug.Id == id);
		}
	}
}