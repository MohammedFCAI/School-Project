namespace SchoolProject.Core.Mappings.Users
{
	public partial class UserProfile : Profile
	{
		public UserProfile()
		{
			GetUsersListMapping();
			AddUserCommandMapping();
			UpdateUserCommandMapping();
			GetUserByIdMpping();
		}
	}
}
