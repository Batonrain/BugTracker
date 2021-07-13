using AutoMapper;

namespace BugTracker.Helpers
{
	public class StatusConverter : IValueConverter<int, string>
	{
		public string Convert(int source, ResolutionContext context)
		{
			switch (source)
			{
				case 0:
					return "Open";
				case 1:
					return "In progress";
				case 2:
					return "Done";
				default:
					return "Unexpected status";
			}
		}
	}
}