namespace SchoolProject.API.Controllers
{
	[Route("api/subjects")]
	[ApiController]
	public class SubjectsController : AppControllerBase
	{
		private readonly IMediator _mediator;

		public SubjectsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetSubjects()
		{
			var requset = await _mediator.Send(new GetSubjectListQuery());
			return NewResult(requset);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSubjectById(int id)
		{
			var requset = await _mediator.Send(new GetSubjectByIdQuery(id));
			return NewResult(requset);
		}

		[HttpPost]
		public async Task<IActionResult> AddSubject([FromForm] AddSubjectCommand subject)
		{
			var requset = await _mediator.Send(subject);
			return NewResult(requset);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSubject([FromForm] UpdateSubjectCommand subject)
		{
			var requset = await _mediator.Send(subject);
			return NewResult(requset);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSubject(int id)
		{
			var requset = await _mediator.Send(new DeleteSubjectCommand(id));
			return NewResult(requset);
		}
	}
}
