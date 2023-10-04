using SchoolProject.Core.Features.DepartmentCourses.Queries.Responses;

namespace SchoolProject.Core.Mappings.DepartmentSubjects
{
	public partial class DepartmentSubjectProfile
	{

		public void GetDepartmentSubjectByIdMapping()
		{
			CreateMap<Subject, GetDepartmentSubjectListResponse>()
				.ForMember(des => des.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
				.ForMember(des => des.SubjectName, opt => opt.MapFrom(src => src.Name));
		}
	}
}
