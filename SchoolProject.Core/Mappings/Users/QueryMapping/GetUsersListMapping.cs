using SchoolProject.Core.Features.Users.Queries.Responses;
using SchoolProject.Data.Entities.Identities;

namespace SchoolProject.Core.Mappings.Users
{
	public partial class UserProfile
	{

		public void GetUsersListMapping()
		{
			CreateMap<User, GetUsersResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
				.ForMember(des => des.UserName, opt => opt.MapFrom(src => src.UserName))
				.ForMember(des => des.FirstName, opt => opt.MapFrom(src => src.FirstName))
				.ForMember(des => des.LastName, opt => opt.MapFrom(src => src.LastName))
				.ForMember(des => des.Address, opt => opt.MapFrom(src => src.Address))
				.ForMember(des => des.Country, opt => opt.MapFrom(src => src.Country));
		}
	}
}
