namespace SchoolProject.Core.Mappings.Students
{
	public partial class StudentProfile
	{
		public void GetStudentListMapping()
		{
			CreateMap<Student, GetStudentListResponse>()
				.ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.StudentId)).ReverseMap();
		}
	}
}
