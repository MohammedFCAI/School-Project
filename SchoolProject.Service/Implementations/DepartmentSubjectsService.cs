namespace SchoolProject.Service.Implementations
{
	public class DepartmentSubjectsService : IDepartmentSubjectsService
	{
		private readonly IUnitOfWork _unitOfWork;

		public DepartmentSubjectsService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<DepartmentSubject> AddSubjectToDepartment(int departmentId, int subjectId)
		{
			var departmentSubject = await _unitOfWork.DepartmentSubjectsRepository.AddSubjectToDepartment(departmentId, subjectId);

			if (departmentSubject == null)
				return null;

			return departmentSubject;
		}

		public async Task<string> DeleteDepartmentSubject(int departmentId, int subjectId)
		{
			var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(departmentId);

			if (department == null)
				return "DepartmentIsNull";

			var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(subjectId);

			if (subject == null)
				return "SubjectIsNull";


			//if (student.StudentSubjects == null || student.StudentSubjects.Count == 0)
			//	return "CourseNotFound";

			var success = await _unitOfWork.DepartmentSubjectsRepository.DeleteDepartmentSubject(departmentId, subjectId);

			if (!success)
				return "false";

			return "true";
		}

		public async Task<List<Subject>> GetDepartmentSubjects(int departmentId)
		{
			var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(departmentId);

			var subjects = _unitOfWork.DepartmentSubjectsRepository.GetDepartmentSubjects(departmentId);


			return subjects;
		}
	}
}
