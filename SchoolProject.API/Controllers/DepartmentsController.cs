namespace SchoolProject.API.Controllers
{
	[Route("api/departments")]
	[ApiController]
	public class DepartmentsController : AppControllerBase
	{
		private readonly IMediator _mediator;

		public DepartmentsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDepartments()
		{
			var requset = await _mediator.Send(new GetDepartmentsListQuery());
			return NewResult(requset);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDepartmentById(int id)
		{
			var requset = await _mediator.Send(new GetDepartmentByIdQuery(id));
			return NewResult(requset);
		}

		[HttpPost]
		public async Task<IActionResult> AddDepartment([FromForm] AddDepartmentCommand department)
		{
			var requset = await _mediator.Send(department);
			return NewResult(requset);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateDepartment([FromForm] UpdateDepartmentCommand department)
		{
			var requset = await _mediator.Send(department);
			return NewResult(requset);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDepartment(int id)
		{
			var requset = await _mediator.Send(new DeleteDepartmentCommand(id));
			return NewResult(requset);
		}
	}
}
