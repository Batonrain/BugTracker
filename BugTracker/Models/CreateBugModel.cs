using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
	public class CreateBugModel
	{
		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[Required]
		[StringLength(1000)]
		public string Description { get; set; }
	}
}