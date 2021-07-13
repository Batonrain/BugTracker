using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Models;

namespace BugTracker.Services
{
	public interface IBugService
	{
		Task<IEnumerable<BugModel>> GetAll();
		Task<BugModel> Get(long id);
		Task<IEnumerable<BugModel>> Get(string name, string description, int? status);
		Task<long> Add(CreateBugModel model);
		Task Update(int id, UpdateBugModel model);
		Task Delete(int id);
		Task<bool> IsExists(int id);
	}
}