using SchoolProject.Core.Features.Users.Queries.Responses;

namespace SchoolProject.Core.Features.Users.Queries.Models
{
	public class GetUserByIdQuery : IRequest<Response<GetUsersResponse>>
	{
		public int Id { get; set; }

		public GetUserByIdQuery(int id)
		{
			Id = id;
		}
	}
}

