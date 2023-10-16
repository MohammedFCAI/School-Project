using Microsoft.IdentityModel.Tokens;

namespace SchoolProject.Infrastructure.Repositories
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IStudentRepository _studentRepository;

		public DepartmentRepository(ApplicationDbContext context, IStudentRepository studentRepository)
		{
			_context = context;
			_studentRepository = studentRepository;
		}

		public async Task<Department> AddAsync(Department department)
		{
			await _context.Departments.AddAsync(department);
			await _context.SaveChangesAsync();
			return department;
		}

		public async Task<Department> DeleteAsync(int departmentId)
		{
			// if department has students or : return "You cann't delete it.."

			var department = await _context.Departments
			.Where(d => d.DepartmentId == departmentId)
			.Include(d => d.DepartmentSubjects)
			.ThenInclude(ds => ds.Subject)
			.FirstOrDefaultAsync();

			var studentsInDepartment = _studentRepository.GetStudentsByDepartmentId(departmentId);

			var subjectsInDepartment = department.DepartmentSubjects
			   .Select(ds => ds.Subject)
			   .ToList();

			if (studentsInDepartment.IsNullOrEmpty() && subjectsInDepartment.IsNullOrEmpty())
			{
				_context.Departments.Remove(department);
				await _context.SaveChangesAsync();
				return department;
			}

			return null;
		}

		public async Task<List<Department>> GetAllAsync() =>
			await _context.Departments.AsNoTracking().ToListAsync();


		public async Task<Department> GetByIdAsync(int departmentId) =>
			await _context.Departments.AsNoTracking().FirstOrDefaultAsync(i => i.DepartmentId == departmentId);


		public async Task<Department> UpdateAsync(Department department)
		{
			_context.Departments.Update(department);
			await _context.SaveChangesAsync();
			return department;
		}

		public async Task<bool> IsDepartmentNameUnique(string name) =>
			 _context.Departments.AsNoTracking().AsEnumerable()
		.Any(d => string.Equals(d.Name, name, StringComparison.OrdinalIgnoreCase));


		public Department? GetByName(string name)
		{
			return _context.Departments.FirstOrDefault(s => s.Name == name);
		}
	}
}
