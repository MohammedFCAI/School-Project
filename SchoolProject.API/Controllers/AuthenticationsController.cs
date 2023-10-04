using SchoolProject.Core.Features.Authentication.Commands.Models;

namespace SchoolProject.API.Controllers
{
	[Route("api/authentications")]
	[ApiController]
	public class AuthenticationsController : AppControllerBase
	{
		private readonly IMediator _mediator;

		public AuthenticationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("signIn")]
		public async Task<IActionResult> Create([FromForm] SignInCommand user)
		{
			var requset = await _mediator.Send(user);
			return NewResult(requset);
		}

	}
}
