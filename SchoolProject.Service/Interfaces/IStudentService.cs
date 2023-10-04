namespace SchoolProject.Service.Interfaces
{
	public interface IStudentService : IGenericService<Student>
	{
		public List<Student> GetSudentsByDepartmentName(string departmentName);
	}
}
