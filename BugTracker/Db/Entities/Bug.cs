namespace BugTracker.Db.Entities
{
	public class Bug
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Status { get; set; }
	}
}