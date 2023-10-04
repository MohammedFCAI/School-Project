namespace SchoolProject.Core.Features.Departments.Commands.Models
{
	public class AddDepartmentCommand : IRequest<Response<AddDepartmentResponse>>
	{
		public string Name { get; set; }
	}
}
