namespace SchoolProject.Core.Mappings.Students
{
	public partial class StudentProfile : Profile
	{
		public void DeleteStudentMapping()
		{
			CreateMap<DeleteStudentCommand, Student>()
				.ForMember(des => des.StudentId, opt => opt.MapFrom(src => src.Id));
		}
	}
}
