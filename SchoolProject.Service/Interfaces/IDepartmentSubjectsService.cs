namespace SchoolProject.Service.Interfaces
{
	public interface IDepartmentSubjectsService
	{
		public Task<DepartmentSubject> AddSubjectToDepartment(int departmentId, int subjectId);
		public Task<List<Subject>> GetDepartmentSubjects(int id);
		public Task<string> DeleteDepartmentSubject(int departmentId, int subjectId);
	}
}
