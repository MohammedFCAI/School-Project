using SchoolProject.Core.Features.Users.Queries.Responses;
using SchoolProject.Data.Entities.Identities;

namespace SchoolProject.Core.Mappings.Users
{
	public partial class UserProfile
	{

		public void GetUsersListMapping()
		{
			CreateMap<User, GetUsersResponse>();
		}
	}
}
