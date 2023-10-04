using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
	public class GetStudentByIdQuery : IRequest<Response<GetStudentByIdResponse>>
	{
		public int Id { get; set; }

		public GetStudentByIdQuery(int id)
		{
			Id = id;
		}
	}
}
