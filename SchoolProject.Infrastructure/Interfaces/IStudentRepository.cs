namespace SchoolProject.Infrastructure.Interfaces
{
	public interface IStudentRepository : IGenericRepository<Student>
	{
		List<Student> GetStudentsByDepartmentId(int departmentId);
		public List<Student> GetSudentsByDepartmentName(string departmentName);
	}
}
