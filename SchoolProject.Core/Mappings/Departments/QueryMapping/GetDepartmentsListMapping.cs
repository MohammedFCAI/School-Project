namespace SchoolProject.Core.Mappings.Departments
{
	public partial class DepartmentProfile
	{
		public void GetDepartmentsListMapping()
		{
			CreateMap<Department, GetDepartmentsListResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.DepartmentId));
		}
	}
}
