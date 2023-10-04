namespace SchoolProject.Core.Mappings.Departments
{
	public partial class DepartmentProfile
	{
		public void GetDepartmentByIdMapping()
		{
			CreateMap<Department, GetDepartmentByIdResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.DepartmentId));
		}
	}
}
