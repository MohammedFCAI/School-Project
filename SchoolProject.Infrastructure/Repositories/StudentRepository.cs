namespace SchoolProject.Infrastructure.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private readonly ApplicationDbContext _context;

		public StudentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Student> AddAsync(Student student)
		{
			await _context.Students.AddAsync(student);
			_context.Students.Include(i => i.Department).AsNoTracking();

			await _context.SaveChangesAsync();
			return student;
		}

		public async Task<List<Student>> GetAllAsync() =>
			await _context.Students.Include(i => i.Department).AsNoTracking().ToListAsync();

		public async Task<Student> GetByIdAsync(int studentId) =>
			await _context.Students.Include(i => i.Department).AsNoTracking().FirstOrDefaultAsync(i => i.StudentId == studentId);


		public async Task<Student> UpdateAsync(Student student)
		{
			_context.Students.Update(student);
			await _context.SaveChangesAsync();
			return student;
		}

		public IQueryable<Student> GetTableNoTracking()
		{
			return _context.Set<Student>().AsNoTracking().AsQueryable();
		}

		public async Task<Student> DeleteAsync(int studentId)
		{
			var student = await GetByIdAsync(studentId);
			_context.Students.Remove(student);
			await _context.SaveChangesAsync();
			return student;
		}

		public List<Student> GetStudentsByDepartmentId(int departmentId)
		{
			return _context.Students.Where(s => s.DepartmentId == departmentId).ToList();
		}

		public List<Student> GetSudentsByDepartmentName(string departmentName)
		{
			return _context.Students.Include(d => d.Department).Include(s => s.StudentSubjects).Where(s => s.Department.Name == departmentName).ToList();
		}
	}
}