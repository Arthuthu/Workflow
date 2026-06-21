using Microsoft.EntityFrameworkCore;
using Workflow.Domain.Entities;

namespace Workflow.Domain.Context
{
    public sealed class WorkflowContext : DbContext
	{
		public WorkflowContext(DbContextOptions<WorkflowContext> options) : base(options)
		{
		}

		public DbSet<Work> Work { get; set; }
		public DbSet<WorkHistory> WorkHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
		}
	}
}
