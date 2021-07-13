using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
	public class UpdateBugModel
	{
		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[Required]
		[StringLength(1000)]
		public string Description { get; set; }

		[Required]
		[Range(0,2, ErrorMessage = "Status could be only 0, 1 and 2")]
		public int Status { get; set; }
	}
}