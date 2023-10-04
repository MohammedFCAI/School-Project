namespace SchoolProject.Core.Features.Students.Commands.Models
{
	public class UpdateStudentCommand : BaseEntityRequest, IRequest<Response<UpdateStudentResponse>>
	{
		public int Id { get; set; }
	}
}
