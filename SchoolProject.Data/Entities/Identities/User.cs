using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities.Identities
{
	public class User : IdentityUser<int>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? Address { get; set; }
		public string? Country { get; set; }
	}
}
