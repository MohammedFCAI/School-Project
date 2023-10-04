using SchoolProject.Core.Features.Subjects.Queries.Responses;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
	public class GetSubjectByIdQuery : IRequest<Response<GetSubjectByIdResponse>>
	{
		public int Id { get; set; }

		public GetSubjectByIdQuery(int id)
		{
			Id = id;
		}
	}
}
