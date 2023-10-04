namespace SchoolProject.Service.Interfaces
{
	public interface IStudentSubjectsService
	{
		public Task<string> AddSubjectToStudent(int studentId, int subjectId);
		public Task<List<Subject>> GetStudentSubject(int id);
		public Task<string> DeleteStudentSubject(int studentId, int subjectId);
	}
}
