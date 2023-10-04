namespace SchoolProject.Infrastructure.Repositories
{
	public class StudentSubjectsRepository : IStudentSubjectsRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IStudentRepository _studentRepository;
		private readonly ISubjectRepository _subjectRepository;
		private readonly IDepartmentRepository _departmentRepository;

		public StudentSubjectsRepository(ApplicationDbContext context, IStudentRepository studentRepository, ISubjectRepository subjectRepository, IDepartmentRepository departmentRepository)
		{
			_context = context;
			_studentRepository = studentRepository;
			_subjectRepository = subjectRepository;
			_departmentRepository = departmentRepository;
		}

		public async Task<string> AddSubjectToStudent(int studentId, int subjectId)
		{

			var student = await _studentRepository.GetByIdAsync(studentId);
			var subject = await _subjectRepository.GetByIdAsync(subjectId);

			if (student.StudentSubjects == null)
				student.StudentSubjects = new List<StudentSubject>();


			var studentSubject = new StudentSubject
			{
				StudentId = student.StudentId,
				SubjectId = subject.SubjectId
			};

			var existingStudentSubject = await _context.StudentSubjects
			.FirstOrDefaultAsync(ss => ss.StudentId == studentId && ss.SubjectId == subjectId);

			if (existingStudentSubject != null)
				return "SubjectIsExist";

			var department = await _context.Departments
			.Where(d => d.DepartmentId == student.DepartmentId)
			.Include(d => d.DepartmentSubjects)
			.ThenInclude(ds => ds.Subject)
			.FirstOrDefaultAsync();

			var subjectsInDepartment = department.DepartmentSubjects
			   .Select(ds => ds.Subject)
			   .ToList();

			if (subjectsInDepartment.Contains(subject))
			{
				student.StudentSubjects.Add(studentSubject);
				_context.StudentSubjects.Add(studentSubject);
				await _context.SaveChangesAsync();
				return "Added";
			}

			return "NotAllowed";
		}

		public async Task<bool> DeleteStudentSubject(int studentId, int subjectId)
		{
			var student = await _studentRepository.GetByIdAsync(studentId);

			var studentSubject = _context.StudentSubjects
			.FirstOrDefault(ss => ss.StudentId == studentId && ss.SubjectId == subjectId);

			if (studentSubject == null) return false;

			student.StudentSubjects.Remove(studentSubject);
			_context.StudentSubjects.Remove(studentSubject);

			await _context.SaveChangesAsync();

			return true;
		}

		public List<Subject> GetStudentSubjects(int studentId)
		{
			var studentCourses = _context.StudentSubjects
			.Where(sc => sc.StudentId == studentId)
			.Select(sc => sc.Subject)
			.ToList();

			return studentCourses;
		}

	}
}
