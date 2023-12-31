﻿namespace SchoolProject.Core
{
	public static class ModuleCoreDependencies
	{
		public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
		{   // Configuration of Mediator
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
			// Configuration of AutoMapper
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			return services;
		}
	}
}
