namespace SchoolProject.Core.Features.Departments.Queries.Models
{
	public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
	{
		public int Id { get; set; }

		public GetDepartmentByIdQuery(int id)
		{
			Id = id;
		}
	}
}
