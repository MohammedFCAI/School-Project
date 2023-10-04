namespace SchoolProject.Infrastructure.Interfaces
{
	public interface ISubjectRepository : IGenericRepository<Subject>
	{
		public Task<bool> IsSubjectNameUnique(string name);
	}
}
