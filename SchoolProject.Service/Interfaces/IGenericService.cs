namespace SchoolProject.Service.Interfaces
{
	public interface IGenericService<T> where T : class
	{
		public Task<List<T>> GetAllList();
		public Task<T> GetById(int entityId);
		public Task<T> Add(T entity);
		public Task<T> Update(T entity);
		public Task<T> Delete(int entityId);
	}
}
