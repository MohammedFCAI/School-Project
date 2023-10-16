namespace SchoolProject.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public IStudentRepository StudentRepository { get; }
		public IDepartmentRepository DepartmentRepository { get; }
		public ISubjectRepository SubjectRepository { get; }
		public IStudentSubjectsRepository StudentSubjectsRepository { get; }
		public IDepartmentSubjectsRepository DepartmentSubjectsRepository { get; }
		public IRefreshTokenRepository RefreshTokenRepository { get; }


		public UnitOfWork(IStudentRepository studentRepository, IDepartmentRepository departmentRepository, ISubjectRepository subjectRepository, IStudentSubjectsRepository studentSubjectsRepository, IDepartmentSubjectsRepository departmentSubjectsRepository, IRefreshTokenRepository refreshTokenRepository)
		{
			StudentRepository = studentRepository;
			DepartmentRepository = departmentRepository;
			SubjectRepository = subjectRepository;
			StudentSubjectsRepository = studentSubjectsRepository;
			DepartmentSubjectsRepository = departmentSubjectsRepository;
			RefreshTokenRepository = refreshTokenRepository;
		}

	}
}
