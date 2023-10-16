using SchoolProject.Data.Entities.Identities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Interfaces
{
	public interface IAuthenticationService
	{
		public Task<SignInResponse> GetJWTToken(User user);
	}
}
