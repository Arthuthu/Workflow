using Microsoft.EntityFrameworkCore;
using Workflow.Application.Interfaces.Repositories;
using Workflow.Application.Interfaces.Services;
using Workflow.Application.Services;
using Workflow.Domain.Context;

namespace UserApi.Configuration
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
		{
			//Service
			services.AddScoped<IWorkService, WorkService>();

			//Repository
			services.AddScoped<IWorkRepository, WorkRepository>();

			return services;
		}

		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<WorkflowContext>(options =>
			{
				options.UseNpgsql(config.GetConnectionString("WorkConnection"),
					assembly => assembly.MigrationsAssembly(typeof(WorkflowContext)
					.Assembly.FullName));
			});

			return services;
		}

		public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
		{
			services.AddCors(policy =>
			{
				policy.AddPolicy("OpenCorsPolicy", opt =>
				{
					opt
					.AllowAnyOrigin()
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			return services;
		}
	}
}
