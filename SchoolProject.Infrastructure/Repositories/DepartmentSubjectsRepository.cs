namespace SchoolProject.Infrastructure.Repositories
{
	public class DepartmentSubjectsRepository : IDepartmentSubjectsRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly ISubjectRepository _subjectRepository;
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentSubjectsRepository(ApplicationDbContext context, ISubjectRepository subjectRepository, IDepartmentRepository departmentRepository)
		{
			_context = context;
			_subjectRepository = subjectRepository;
			_departmentRepository = departmentRepository;
		}

		public async Task<DepartmentSubject> AddSubjectToDepartment(int departmentId, int subjectId)
		{
			var department = await _context.Departments.FindAsync(departmentId);

			var subject = await _subjectRepository.GetByIdAsync(subjectId);

			if (department.DepartmentSubjects == null)
				department.DepartmentSubjects = new List<DepartmentSubject>();



			var departmentSubject = new DepartmentSubject
			{
				DepartmentId = department.DepartmentId,
				SubjectId = subject.SubjectId
			};

			var existingDepartmentSubject = await _context.DepartmentSubjects
			.FirstOrDefaultAsync(ss => ss.DepartmentId == departmentId && ss.SubjectId == subjectId);

			if (existingDepartmentSubject != null)
				return null;

			department.DepartmentSubjects.Add(departmentSubject);
			_context.DepartmentSubjects.Add(departmentSubject);
			await _context.SaveChangesAsync();

			return departmentSubject;
		}

		public async Task<bool> DeleteDepartmentSubject(int departmentId, int subjectId)
		{
			var department = await _departmentRepository.GetByIdAsync(departmentId);

			var departmentSubject = _context.DepartmentSubjects
			.FirstOrDefault(ss => ss.DepartmentId == departmentId && ss.SubjectId == subjectId);

			if (departmentSubject == null) return false;

			department.DepartmentSubjects.Remove(departmentSubject);
			_context.DepartmentSubjects.Remove(departmentSubject);

			await _context.SaveChangesAsync();

			return true;
		}

		public List<Subject> GetDepartmentSubjects(int departmentId)
		{
			var departmentSubject = _context.DepartmentSubjects
			.Where(sc => sc.DepartmentId == departmentId)
			.Select(sc => sc.Subject)
			.ToList();

			return departmentSubject;
		}
	}
}
