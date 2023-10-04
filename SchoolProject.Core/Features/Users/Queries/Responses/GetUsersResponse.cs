namespace SchoolProject.Core.Features.Users.Queries.Responses
{
	public class GetUsersResponse
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Country { get; set; }
		public string Address { get; set; }
	}
}
