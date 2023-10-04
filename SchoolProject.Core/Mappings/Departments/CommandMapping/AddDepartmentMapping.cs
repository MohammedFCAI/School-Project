namespace SchoolProject.Core.Mappings.Departments
{
	public partial class DepartmentProfile
	{
		public void AddDepartmentMapping()
		{
			CreateMap<AddDepartmentCommand, Department>()
				.ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name));

			CreateMap<Department, AddDepartmentResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.DepartmentId));
		}
	}
}
