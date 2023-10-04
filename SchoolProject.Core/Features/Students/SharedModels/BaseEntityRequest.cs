namespace SchoolProject.Core.Features.Students.SharedModels
{
	public class BaseEntityRequest
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public int DepartmentId { get; set; }
	}
}
