using SchoolProject.Core.Features.StudentCourse.Queries.Responses;

namespace SchoolProject.Core.Features.StudentCourse.Queries.Models
{
	public class GetSubjectsForStudentQuery : IRequest<Response<List<GetStudentSubjectListResponse>>>
	{
		public int Id { get; set; }

		public GetSubjectsForStudentQuery(int id)
		{
			Id = id;
		}
	}
}
