namespace SchoolProject.Infrastructure
{
	public static class ModuleInfrastructureDependencies
	{
		public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
		{
			services.AddTransient<IStudentRepository, StudentRepository>();
			services.AddTransient<IDepartmentRepository, DepartmentRepository>();
			services.AddTransient<ISubjectRepository, SubjectRepository>();
			services.AddTransient<IStudentSubjectsRepository, StudentSubjectsRepository>();
			services.AddTransient<IDepartmentSubjectsRepository, DepartmentSubjectsRepository>();

			return services;
		}
	}
}
