namespace SchoolProject.Core.Mappings.Students
{
	public partial class StudentProfile : Profile
	{
		public StudentProfile()
		{
			GetStudentListMapping();
			GetStudentByIdMapping();
			AddStudentMapping();
			UpdateStudentMapping();
			DeleteStudentMapping();
			GetStudentByIdMapping();
			GetStudentByDepartmentNameMapping();
		}
	}
}
