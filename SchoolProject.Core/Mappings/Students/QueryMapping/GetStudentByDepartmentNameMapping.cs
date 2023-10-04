namespace SchoolProject.Core.Mappings.Students
{
	public partial class StudentProfile
	{
		public void GetStudentByDepartmentNameMapping()
		{
			CreateMap<Student, GetStudentByDepartmentNameResponse>()
				.ForMember(des => des.StudentId, opt => opt.MapFrom(src => src.StudentId));
		}
	}
}

