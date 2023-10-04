using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities.Identities;

namespace SchoolProject.Core.Features.Users.Commands.Handlers
{
	public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>,
		IRequestHandler<UpdateUserCommand, Response<string>>, IRequestHandler<DeleteUserCommand, Response<string>>,
		IRequestHandler<ChangeUserPasswordCommmand, Response<string>>
	{
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManger;


		public UserCommandHandler(IMapper mapper, UserManager<User> userManger)
		{
			_mapper = mapper;
			_userManger = userManger;
		}

		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			// If an email is exists
			var user = await _userManger.FindByEmailAsync(request.Email);

			if (user != null)
				return BadRequest<string>("Email is exists..");

			// If an Username is exists
			var userByUsername = await _userManger.FindByNameAsync(request.UserName);

			if (userByUsername != null)
				return BadRequest<string>("Username is exists..");

			// Mapping:		
			var identityUser = _mapper.Map<User>(request);

			if (request.Password != request.ConfirmPassword)
				return BadRequest<string>("Password and ConfirmPassword do not match.");

			var create = await _userManger.CreateAsync(identityUser, request.Password);

			if (!create.Succeeded)
				return BadRequest<string>(create.Errors.FirstOrDefault().Description + " ☹");

			// Success
			return Created("User Created 😀");

		}

		public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManger.FindByIdAsync(request.Id.ToString());

			if (user == null)
				return BadRequest<string>("User id is not found 🙁🙁..");

			var newUser = _mapper.Map(request, user);

			var userByName = await _userManger.Users.FirstOrDefaultAsync(i => i.UserName == newUser.UserName && i.Id != newUser.Id);

			var result = await _userManger.UpdateAsync(newUser);

			if (!result.Succeeded)
				return BadRequest<string>("Update failed 🙁🙁..");

			return Success("Updated 😁😁..");

		}

		public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManger.FindByIdAsync(request.Id.ToString());

			if (user == null)
				return BadRequest<string>("User id is not found 🙁🙁..");

			var result = await _userManger.DeleteAsync(user);

			if (!result.Succeeded)
				return BadRequest<string>("Deleted failed 🙁🙁..");

			return Deleted<string>("User Delted 😁😁..");
		}

		public async Task<Response<string>> Handle(ChangeUserPasswordCommmand request, CancellationToken cancellationToken)
		{
			var user = await _userManger.FindByIdAsync(request.Id.ToString());

			if (user == null)
				return BadRequest<string>("User id is not found 🙁🙁..");

			if (request.NewPassword != request.ConfirmNewPassword)
				return BadRequest<string>("Password and ConfirmPassword do not match.");

			var result = await _userManger.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

			#region Another way to change password..
			//var user1 = await _userManger.HasPasswordAsync(user);
			//await _userManger.RemovePasswordAsync(user);
			//await _userManger.AddPasswordAsync(user, request.CurrentPassword); 
			#endregion


			if (!result.Succeeded)
				return BadRequest<string>(" Change password failed 🙁🙁.. " + result.Errors.FirstOrDefault().Description);

			return Success<string>("Password changed Successfully 😁😁..");
		}
	}
}
