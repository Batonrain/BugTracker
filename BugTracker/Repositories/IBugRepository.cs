using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Db.Entities;

namespace BugTracker.Repositories
{
	public interface IBugRepository
	{
		Task<IEnumerable<Bug>> GetAll();
		Task<Bug> Get(long id);
		Task<IEnumerable<Bug>> Get(string name, string description, int? status);
		Task<long> Add(Bug bug);
		Task Update(Bug bug);
		Task Delete(long id);
		Task<bool> IsExists(long id);
	}
}