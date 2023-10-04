namespace SchoolProject.Core.Mappings.Departments
{
	public partial class DepartmentProfile
	{
		public void UpdateDepartmentMapping()
		{
			CreateMap<UpdateDepartmentCommand, Department>()
				.ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.Id));

			CreateMap<Department, UpdateDepartmentResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.DepartmentId));
		}
	}
}
