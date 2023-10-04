using SchoolProject.Core.Features.DepartmentCourses.Commands.Models;

namespace SchoolProject.Core.Mappings.DepartmentSubjects
{
	public partial class DepartmentSubjectProfile
	{
		public void AddDepartmentSubjectMapping()
		{
			CreateMap<AddDepartmentSubjectCommand, DepartmentSubject>()
				.ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
				.ForMember(des => des.SubjectId, opt => opt.MapFrom(src => src.SubjectId));
		}
	}
}
