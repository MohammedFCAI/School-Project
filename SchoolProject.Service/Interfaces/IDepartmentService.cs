namespace SchoolProject.Service.Interfaces
{
	public interface IDepartmentService : IGenericService<Department>
	{
		public Department GetByName(string name);
	}
}
