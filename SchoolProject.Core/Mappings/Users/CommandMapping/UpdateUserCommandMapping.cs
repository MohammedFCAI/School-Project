using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities.Identities;

namespace SchoolProject.Core.Mappings.Users
{
	public partial class UserProfile
	{
		public void UpdateUserCommandMapping()
		{
			CreateMap<UpdateUserCommand, User>();
		}
	}
}