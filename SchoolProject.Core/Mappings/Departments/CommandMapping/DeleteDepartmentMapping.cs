namespace SchoolProject.Core.Mappings.Departments
{
	public partial class DepartmentProfile
	{
		public void DeleteDepartmentMapping()
		{
			CreateMap<DeleteDepartmentCommand, Department>()
				.ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.Id));
		}
	}
}
