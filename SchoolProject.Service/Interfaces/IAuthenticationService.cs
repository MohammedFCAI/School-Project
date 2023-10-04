using SchoolProject.Data.Entities.Identities;

namespace SchoolProject.Service.Interfaces
{
	public interface IAuthenticationService
	{
		public Task<string> GetJWTToken(User user);
	}
}
