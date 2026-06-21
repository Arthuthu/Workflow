using Microsoft.EntityFrameworkCore;
using Workflow.Domain.Entities;

namespace Workflow.Domain.Context
{
    public sealed class WorkContext : DbContext
	{
		public WorkContext(DbContextOptions<WorkContext> options) : base(options)
		{
		}

		public DbSet<Work> Work { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
		}
	}
}
