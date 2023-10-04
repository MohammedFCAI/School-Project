using SchoolProject.Core.Features.StudentSubjects.Commands.Models;

namespace SchoolProject.Core.Mappings.StudentSubjects
{
	public partial class StudentSubjectProfile
	{
		public void AddStudentSubjectMapping()
		{
			CreateMap<AddStudentSubjectCommand, StudentSubject>()
				.ForMember(des => des.StudentId, opt => opt.MapFrom(src => src.StudentId))
				.ForMember(des => des.SubjectId, opt => opt.MapFrom(src => src.SubjectId));
		}
	}
}
