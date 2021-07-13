using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using BugTracker.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Db
{
	public class DataContext : DbContext
	{
		protected readonly IConfiguration Configuration;

		public DataContext(IConfiguration configuration)
		{
			Configuration = configuration;
			// Database.EnsureDeleted();
			// Database.EnsureCreated();
		}

		public DbSet<Bug> Bugs { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var data = new List<Bug>()
			{
				new Bug
				{
					Id = 1,
					Name = "Front issue",
					Description =
						"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
					Status = 0,
				},
				new Bug
				{
					Id = 2,
					Name = "Back issue",
					Description =
						"Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
					Status = 1,
				},
				new Bug
				{
					Id = 3,
					Name = "Nobody issue",
					Description =
						"Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. ",
					Status = 2,
				},
			};
			modelBuilder.Entity<Bug>().HasData(data);
		}
	}
}