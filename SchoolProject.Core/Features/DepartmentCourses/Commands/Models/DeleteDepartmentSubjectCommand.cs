namespace SchoolProject.Core.Features.DepartmentCourses.Commands.Models
{
	public class DeleteDepartmentSubjectCommand : IRequest<Response<string>>
	{
		public int DepartmentId { get; set; }
		public int SubjectId { get; set; }

		public DeleteDepartmentSubjectCommand(int departmentId, int subjectId)
		{
			DepartmentId = departmentId;
			SubjectId = subjectId;
		}
	}
}
