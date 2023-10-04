namespace SchoolProject.Core.Features.StudentSubjects.Commands.Models
{
	public class AddStudentSubjectCommand : IRequest<Response<string>>
	{
		public int StudentId { get; set; }
		public int SubjectId { get; set; }
	}
}
