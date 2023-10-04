using SchoolProject.Core.Features.Subjects.Commands.Responses;

namespace SchoolProject.Core.Features.Subjects.Commands.Models
{
	public class AddSubjectCommand : IRequest<Response<AddSubjectResponse>>
	{
		public string Name { get; set; }
	}
}
