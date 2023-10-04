using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Features.Users.Queries.Models;

namespace SchoolProject.API.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : AppControllerBase
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var requset = await _mediator.Send(new GetUsersListQuery());
			return NewResult(requset);
		}

		[HttpGet("id")]
		public async Task<IActionResult> GetUserById(int id)
		{
			var requset = await _mediator.Send(new GetUserByIdQuery(id));
			return NewResult(requset);
		}

		[HttpPost]
		public async Task<IActionResult> AddUser([FromBody] AddUserCommand user)
		{
			var request = await _mediator.Send(user);
			return NewResult(request);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand user)
		{
			var requset = await _mediator.Send(user);
			return NewResult(requset);
		}

		[HttpDelete("id")]
		public async Task<IActionResult> UpdateUser(int id)
		{
			var requset = await _mediator.Send(new DeleteUserCommand(id));
			return NewResult(requset);
		}

		[HttpPut("change-password")]
		public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommmand user)
		{
			var requset = await _mediator.Send(user);
			return NewResult(requset);
		}

	}
}
