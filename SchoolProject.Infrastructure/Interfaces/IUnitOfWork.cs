namespace SchoolProject.Infrastructure.Interfaces
{
	public interface IUnitOfWork
	{
		IStudentRepository StudentRepository { get; }
		IDepartmentRepository DepartmentRepository { get; }
		ISubjectRepository SubjectRepository { get; }
		IStudentSubjectsRepository StudentSubjectsRepository { get; }
		IDepartmentSubjectsRepository DepartmentSubjectsRepository { get; }
	}
}
