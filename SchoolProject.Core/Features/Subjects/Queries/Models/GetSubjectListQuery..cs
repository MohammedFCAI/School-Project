using SchoolProject.Core.Features.Subjects.Queries.Responses;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
	public class GetSubjectListQuery : IRequest<Response<List<GetSubjectListResponse>>>
	{
	}
}
