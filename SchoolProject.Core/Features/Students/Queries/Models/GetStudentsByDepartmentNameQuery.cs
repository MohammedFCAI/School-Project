namespace SchoolProject.Core.Features.Students.Queries.Models
{
	public class GetStudentsByDepartmentNameQuery : IRequest<Response<List<GetStudentByDepartmentNameResponse>>>
	{
		public string Name { get; set; }

		public GetStudentsByDepartmentNameQuery(string name)
		{
			Name = name;
		}
	}
}
