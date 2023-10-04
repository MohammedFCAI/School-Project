using SchoolProject.Core.Features.Subjects.Commands.Responses;

namespace SchoolProject.Core.Features.Subjects.Commands.Models
{
	public class UpdateSubjectCommand : IRequest<Response<UpdateSubjectResponse>>
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

