namespace SchoolProject.Service.Implementations
{
	public class StudentService : IStudentService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IDepartmentService _departmentService;

		public StudentService(IUnitOfWork unitOfWork, IDepartmentService departmentService)
		{
			_unitOfWork = unitOfWork;
			_departmentService = departmentService;
		}

		public async Task<Student> Add(Student student)
		{
			await _unitOfWork.StudentRepository.AddAsync(student);
			return student;
		}

		public async Task<Student> Delete(int id)
		{
			var student = await GetById(id);
			await _unitOfWork.StudentRepository.DeleteAsync(id);
			return student;
		}

		public async Task<List<Student>> GetAllList() =>
			await _unitOfWork.StudentRepository.GetAllAsync();

		public async Task<Student> GetById(int id) =>
			await _unitOfWork.StudentRepository.GetByIdAsync(id);

		public List<Student> GetSudentsByDepartmentName(string departmentName)
		{
			var department = _departmentService.GetByName(departmentName);

			if (department == null)
				return null;

			var students = _unitOfWork.StudentRepository.GetSudentsByDepartmentName(departmentName);

			return students;
		}

		public async Task<Student> Update(Student student)
		{
			var result = await _unitOfWork.StudentRepository.UpdateAsync(student);

			return result;
		}
	}
}
