namespace SchoolProject.Core.Mappings.Students
{
	public partial class StudentProfile : Profile
	{
		public void UpdateStudentMapping()
		{

			CreateMap<UpdateStudentCommand, Student>()
				.ForMember(des => des.StudentId, opt => opt.MapFrom(src => src.Id))
				.ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));



			CreateMap<Student, UpdateStudentResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.StudentId))
				.ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));

		}
	}
}