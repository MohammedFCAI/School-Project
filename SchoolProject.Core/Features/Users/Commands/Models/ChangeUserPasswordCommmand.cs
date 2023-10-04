namespace SchoolProject.Core.Features.Users.Commands.Models
{
	public class ChangeUserPasswordCommmand : IRequest<Response<string>>
	{
		public int Id { get; set; }
		public string CurrentPassword { get; set; }
		public string NewPassword { get; set; }
		public string ConfirmNewPassword { get; set; }

	}
}
