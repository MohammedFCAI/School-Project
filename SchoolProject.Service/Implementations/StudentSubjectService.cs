namespace SchoolProject.Service.Implementations
{
	public class StudentSubjectService : IStudentSubjectsService
	{
		private readonly IUnitOfWork _unitOfWork;

		public StudentSubjectService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<string> AddSubjectToStudent(int studentId, int subjectId)
		{
			var studentSubject = await _unitOfWork.StudentSubjectsRepository.AddSubjectToStudent(studentId, subjectId);

			return studentSubject;
		}

		public async Task<string> DeleteStudentSubject(int studentId, int subjectId)
		{
			var student = await _unitOfWork.StudentRepository.GetByIdAsync(studentId);

			if (student == null)
				return "StudentIsNull";

			var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(subjectId);

			if (subject == null)
				return "SubjectIsNull";


			//if (student.StudentSubjects == null || student.StudentSubjects.Count == 0)
			//	return "CourseNotFound";

			var success = await _unitOfWork.StudentSubjectsRepository.DeleteStudentSubject(studentId, subjectId);

			if (!success)
				return "false";

			return "true";
		}

		public async Task<List<Subject>> GetStudentSubject(int studentId)
		{
			var student = await _unitOfWork.StudentRepository.GetByIdAsync(studentId);

			var subjects = _unitOfWork.StudentSubjectsRepository.GetStudentSubjects(studentId);

			return subjects;
		}
	}
}
