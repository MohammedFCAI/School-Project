using SchoolProject.Core.Features.StudentCourse.Commands.Models;
using SchoolProject.Core.Features.StudentCourse.Queries.Models;
using SchoolProject.Core.Features.StudentSubjects.Commands.Models;

namespace SchoolProject.API.Controllers
{
	[Route("api/studentCourses")]
	[ApiController]
	public class StudentSubjectsController : AppControllerBase
	{
		private readonly IMediator _mediator;

		public StudentSubjectsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> AddStudentCourse([FromForm] AddStudentSubjectCommand course)
		{
			var request = await _mediator.Send(course);
			return NewResult(request);
		}

		[HttpGet("students/{id}")]
		public async Task<IActionResult> GetStudentCourses(int id)
		{
			var request = await _mediator.Send(new GetSubjectsForStudentQuery(id));
			return NewResult(request);
		}

		[HttpDelete("students/{studentId}/courses/{courseId}")]
		public async Task<IActionResult> DeleteStudentCourses(int studentId, int courseId)
		{
			var request = await _mediator.Send(new DeleteStudentSubjectCommand(studentId, courseId));
			return NewResult(request);
		}
	}
}
