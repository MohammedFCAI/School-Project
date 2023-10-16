using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities.Identities
{
	public class UserRefreshToken
	{
		[Key]
		public int Id { get; set; }
		public string UserId { get; set; }
		public string? Token { get; set; }
		public string? RefreshToken { get; set; }
		public string JwtId { get; set; }
		public bool IsUsed { get; set; }
		public bool IsRevoked { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ExpireDate { get; set; }

		[ForeignKey(nameof(UserId))]
		[InverseProperty(nameof(User.RefreshTokens))]
		public virtual User? User { get; set; }
	}
}
