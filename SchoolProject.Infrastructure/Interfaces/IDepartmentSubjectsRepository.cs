namespace SchoolProject.Infrastructure.Interfaces
{
	public interface IDepartmentSubjectsRepository
	{
		public Task<DepartmentSubject> AddSubjectToDepartment(int departmentId, int subjectId);
		public List<Subject> GetDepartmentSubjects(int departmentId);
		public Task<bool> DeleteDepartmentSubject(int departmentId, int subjectId);
	}
}
