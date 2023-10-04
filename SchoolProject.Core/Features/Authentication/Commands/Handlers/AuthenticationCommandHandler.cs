using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.Entities.Identities;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
	public class AuthenticationCommandHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<string>>
	{
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IAuthenticationService _authenticationService;

		public AuthenticationCommandHandler(IMapper mapper, UserManager<User> userManager, IAuthenticationService authenticationService, SignInManager<User> signInManager)
		{
			_mapper = mapper;
			_userManager = userManager;
			_authenticationService = authenticationService;
			_signInManager = signInManager;
		}

		public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
		{

			var user = await _userManager.FindByNameAsync(request.UserName);

			var userPass = _userManager.CheckPasswordAsync(user, request.Password);

			if (user is null || userPass.Result is false)
				return NotFound<string>("Error in username or password 😶😶..");

			// Generate Token..
			var result = await _authenticationService.GetJWTToken(user);

			return Success(result);
		}

	}
}
