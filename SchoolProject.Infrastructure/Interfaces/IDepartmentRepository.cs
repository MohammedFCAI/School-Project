namespace SchoolProject.Infrastructure.Interfaces
{
	public interface IDepartmentRepository : IGenericRepository<Department>
	{
		public Task<bool> IsDepartmentNameUnique(string name);
		public Department GetByName(string name);
	}
}
