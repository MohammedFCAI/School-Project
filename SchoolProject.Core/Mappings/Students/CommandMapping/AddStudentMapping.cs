namespace SchoolProject.Core.Mappings.Students
{
	public partial class StudentProfile : Profile
	{
		public void AddStudentMapping()
		{
			CreateMap<AddStudentCommand, Student>()
				.ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));


			CreateMap<Student, AddStudentResponse>()
				.ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
		}
	}
}
