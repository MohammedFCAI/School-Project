using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Features.Users.Queries.Models;
using SchoolProject.Core.Features.Users.Queries.Responses;
using SchoolProject.Data.Entities.Identities;

namespace SchoolProject.Core.Features.Users.Queries.Handlers
{
	public class UserQueryHandler : ResponseHandler, IRequestHandler<GetUsersListQuery, Response<List<GetUsersResponse>>>,
													IRequestHandler<GetUserByIdQuery, Response<GetUsersResponse>>
	{

		private readonly UserManager<User> _userManger;
		private readonly IMapper _mapper;

		public UserQueryHandler(UserManager<User> userManger, IMapper mapper)
		{
			_userManger = userManger;
			_mapper = mapper;
		}

		public async Task<Response<List<GetUsersResponse>>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
		{
			var users = await _userManger.Users.ToListAsync();

			if (users == null)
				return NotFound<List<GetUsersResponse>>("Users not found 🙁🙁");

			var usersMapper = _mapper.Map<List<GetUsersResponse>>(users);

			return Success(usersMapper, "Success 😁😁..");
		}

		public async Task<Response<GetUsersResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManger.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

			if (user == null)
				return NotFound<GetUsersResponse>("User id is not found 🙁🙁..");

			var userMapper = _mapper.Map<GetUsersResponse>(user);

			return Success(userMapper, "Success 😁😁..");
		}
	}
}
