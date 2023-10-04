namespace SchoolProject.Service.Implementations
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IUnitOfWork _unitOfWork;

		public DepartmentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Department> Add(Department department)
		{
			var IsExist = await _unitOfWork.DepartmentRepository.IsDepartmentNameUnique(department.Name);
			if (IsExist)
				return null;

			var d = department.Name.ToUpper();
			department.Name = d;

			return await _unitOfWork.DepartmentRepository.AddAsync(department);
		}


		public async Task<Department> Delete(int departmentId)
		{
			var result = await _unitOfWork.DepartmentRepository.DeleteAsync(departmentId);

			return result;
		}

		public async Task<List<Department>> GetAllList()
		{
			var departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
			return departments;
		}

		public async Task<Department> GetById(int departmentId)
		{
			var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(departmentId);
			return department;
		}

		public Department GetByName(string name)
		{
			var departmnt = _unitOfWork.DepartmentRepository.GetByName(name);

			return departmnt;
		}

		public async Task<Department> Update(Department department)
		{
			var IsExist = await _unitOfWork.DepartmentRepository.IsDepartmentNameUnique(department.Name);
			if (IsExist)
				return null;
			var d = department.Name.ToUpper();
			department.Name = d;

			return await _unitOfWork.DepartmentRepository.UpdateAsync(department);
		}

	}
}
