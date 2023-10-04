namespace SchoolProject.Infrastructure.Repositories
{
	public class SubjectRepository : ISubjectRepository
	{
		private readonly ApplicationDbContext _context;

		public SubjectRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Subject> AddAsync(Subject subject)
		{
			await _context.Subjects.AddAsync(subject);
			await _context.SaveChangesAsync();
			return subject;
		}

		public async Task<Subject> DeleteAsync(int subjectId)
		{
			var subject = await GetByIdAsync(subjectId);
			_context.Subjects.Remove(subject);
			await _context.SaveChangesAsync();
			return subject;
		}

		public async Task<List<Subject>> GetAllAsync() =>
			await _context.Subjects.AsNoTracking().ToListAsync();


		public async Task<Subject> GetByIdAsync(int subjectId) =>
			await _context.Subjects.AsNoTracking().FirstOrDefaultAsync(i => i.SubjectId == subjectId);


		public async Task<Subject> UpdateAsync(Subject subject)
		{
			_context.Subjects.Update(subject);
			await _context.SaveChangesAsync();
			return subject;
		}

		public async Task<bool> IsSubjectNameUnique(string name) =>
			_context.Subjects.AsNoTracking().AsEnumerable()
		.Any(d => string.Equals(d.Name, name, StringComparison.OrdinalIgnoreCase));
	}
}
