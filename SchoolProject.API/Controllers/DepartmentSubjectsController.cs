using SchoolProject.Core.Features.DepartmentCourses.Commands.Models;
using SchoolProject.Core.Features.DepartmentCourses.Queries.Models;

namespace SchoolProject.API.Controllers
{
	[Route("api/departmentCourses")]
	[ApiController]
	public class DepartmentSubjectsController : AppControllerBase
	{
		private readonly IMediator _mediator;

		public DepartmentSubjectsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> AddDepartmentCourse([FromForm] AddDepartmentSubjectCommand course)
		{
			var request = await _mediator.Send(course);
			return NewResult(request);
		}

		[HttpGet("departments/{departmentId}")]
		public async Task<IActionResult> GetDepartmentCourses(int departmentId)
		{
			var request = await _mediator.Send(new GetSubjectsForDepartmentQuery(departmentId));
			return NewResult(request);
		}

		[HttpDelete("departments/{departmentId}/courses/{courseId}")]
		public async Task<IActionResult> DeleteStudentCourses(int departmentId, int courseId)
		{
			var request = await _mediator.Send(new DeleteDepartmentSubjectCommand(departmentId, courseId));
			return NewResult(request);
		}
	}
}
