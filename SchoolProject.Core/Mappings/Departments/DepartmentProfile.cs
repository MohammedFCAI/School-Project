namespace SchoolProject.Core.Mappings.Departments
{
	public partial class DepartmentProfile : Profile
	{
		public DepartmentProfile()
		{
			GetDepartmentsListMapping();
			GetDepartmentByIdMapping();
			AddDepartmentMapping();
			UpdateDepartmentMapping();
			DeleteDepartmentMapping();
		}
	}
}
