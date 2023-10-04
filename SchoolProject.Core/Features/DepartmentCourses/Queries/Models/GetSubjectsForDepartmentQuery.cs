using SchoolProject.Core.Features.DepartmentCourses.Queries.Responses;

namespace SchoolProject.Core.Features.DepartmentCourses.Queries.Models
{
	public class GetSubjectsForDepartmentQuery : IRequest<Response<List<GetDepartmentSubjectListResponse>>>
	{
		public int Id { get; set; }

		public GetSubjectsForDepartmentQuery(int id)
		{
			Id = id;
		}
	}
}
