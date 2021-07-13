using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.Db.Entities;
using BugTracker.Models;
using BugTracker.Repositories;

namespace BugTracker.Services
{
	public class BugService : IBugService
	{
		private readonly IBugRepository _bugRepository;
		private readonly IMapper _mapper;

		public BugService(IBugRepository bugRepository, IMapper mapper)
		{
			_bugRepository = bugRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<BugModel>> GetAll()
		{
			var bugs = await _bugRepository.GetAll();
			return _mapper.Map<IEnumerable<BugModel>>(bugs);
		}

		public async Task<BugModel> Get(long id)
		{
			var bug = await _bugRepository.Get(id);
			return _mapper.Map<BugModel>(bug);
		}

		public async Task<IEnumerable<BugModel>> Get(string name, string description, int? status)
		{
			var bugs = await _bugRepository.Get(name, description, status);
			return _mapper.Map<IEnumerable<BugModel>>(bugs);
		}

		public async Task<long> Add(CreateBugModel model)
		{
			var bug = _mapper.Map<Bug>(model);
			return await _bugRepository.Add(bug);
		}

		public async Task Update(int id, UpdateBugModel model)
		{
			var bug = _mapper.Map<Bug>(model);
			bug.Id = id;
			await _bugRepository.Update(bug);
		}

		public async Task Delete(int id)
		{
			await _bugRepository.Delete(id);
		}

		public async Task<bool> IsExists(int id)
		{
			return await _bugRepository.IsExists(id);
		}
	}
}