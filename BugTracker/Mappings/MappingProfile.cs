using AutoMapper;
using BugTracker.Db.Entities;
using BugTracker.Helpers;
using BugTracker.Models;

namespace BugTracker.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Bug, BugModel>()
				.ForMember(
					dest => dest.Status,
					opt => opt.ConvertUsing(new StatusConverter()));

			CreateMap<CreateBugModel, Bug>()
				.ForMember(dest => dest.Name,
					opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Description,
				opt => opt.MapFrom(src => src.Description));

			CreateMap<UpdateBugModel, Bug>()
				.ForMember(dest => dest.Name,
					opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Description,
					opt => opt.MapFrom(src => src.Description))
				.ForMember(dest => dest.Status,
				opt => opt.MapFrom(src => src.Status));
		}
	}
}