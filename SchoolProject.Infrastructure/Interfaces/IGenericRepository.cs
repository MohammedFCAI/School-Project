namespace SchoolProject.Infrastructure.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		public Task<List<T>> GetAllAsync();
		public Task<T> GetByIdAsync(int entityId);
		public Task<T> AddAsync(T entity);
		public Task<T> UpdateAsync(T entity);
		public Task<T> DeleteAsync(int entityId);
		//public IQueryable<T> GetTableNoTracking();

	}
}
