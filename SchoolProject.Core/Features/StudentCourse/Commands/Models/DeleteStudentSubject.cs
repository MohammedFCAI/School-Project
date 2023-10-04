namespace SchoolProject.Core.Features.StudentCourse.Commands.Models
{
	public class DeleteStudentSubjectCommand : IRequest<Response<string>>
	{
		public int StudentId { get; set; }
		public int SubjectId { get; set; }

		public DeleteStudentSubjectCommand(int studentId, int subjectId)
		{
			StudentId = studentId;
			SubjectId = subjectId;
		}
	}
}
