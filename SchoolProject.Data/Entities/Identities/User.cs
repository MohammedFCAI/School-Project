using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities.Identities
{
	public class User : IdentityUser
	{
		public User()
		{
			RefreshTokens = new HashSet<UserRefreshToken>();
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? Address { get; set; }
		public string? Country { get; set; }

		[InverseProperty(nameof(UserRefreshToken.User))]
		public virtual ICollection<UserRefreshToken> RefreshTokens { get; set; }
	}
}
