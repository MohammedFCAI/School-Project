using SchoolProject.Infrastructure.Repositories;

namespace SchoolProject.Service
{
	public static class ModuleServiceDependencies
	{
		public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
		{
			services.AddTransient<IStudentService, StudentService>();
			services.AddTransient<IDepartmentService, DepartmentService>();
			services.AddTransient<ISubjectService, SubjectService>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();
			services.AddTransient<IStudentSubjectsService, StudentSubjectService>();
			services.AddTransient<IDepartmentSubjectsService, DepartmentSubjectsService>();
			services.AddTransient<IAuthenticationService, AuthenticationService>();

			return services;
		}
	}
}
