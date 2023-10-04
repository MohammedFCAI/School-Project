namespace SchoolProject.API.Controllers
{
	[Route("api/students")]
	[ApiController]
	public class StudentsController : AppControllerBase
	{
		private readonly IMediator _mediator;

		public StudentsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllStudents()
		{
			var request = await _mediator.Send(new GetStudentListQuery());
			return NewResult(request);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetStudentById(int id)
		{
			//var request = await _mediator.Send(new GetStudentByIdQuery(id));
			var request = await Mediator.Send(new GetStudentByIdQuery(id));
			return NewResult(request);
		}

		[HttpPost]
		public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand student)
		{
			// var request = await _mediator.Send(student);
			var request = await Mediator.Send(student);
			return NewResult(request);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand student)
		{
			var request = await _mediator.Send(student);

			return NewResult(request);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStudent(int id)
		{
			var request = await _mediator.Send(new DeleteStudentCommand(id));

			return NewResult(request);
		}


		[HttpGet("departments/{name}")]
		public async Task<IActionResult> GetByDepartmentName(string name)
		{
			var request = await Mediator.Send(new GetStudentsByDepartmentNameQuery(name));
			return NewResult(request);
		}
	}
}
