namespace SchoolProject.Core.Mappings.Students
{
	public partial class StudentProfile
	{
		public void GetStudentByIdMapping()
		{
			CreateMap<Student, GetStudentByIdResponse>()
				.ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department.Name)).ReverseMap();
		}
	}
}
