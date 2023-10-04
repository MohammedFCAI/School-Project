namespace SchoolProject.Infrastructure.Interfaces
{
	public interface IStudentSubjectsRepository
	{
		public Task<string> AddSubjectToStudent(int studentId, int subjectId);
		public List<Subject> GetStudentSubjects(int studentId);
		public Task<bool> DeleteStudentSubject(int studentId, int subjectId);
	}
}
