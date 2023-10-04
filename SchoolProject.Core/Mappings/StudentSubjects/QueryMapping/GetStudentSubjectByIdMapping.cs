using SchoolProject.Core.Features.StudentCourse.Queries.Responses;

namespace SchoolProject.Core.Mappings.StudentSubjects
{
	public partial class StudentSubjectProfile
	{
		public void GetStudentSubjectByIdMapping()
		{
			CreateMap<Subject, GetStudentSubjectListResponse>()
				.ForMember(des => des.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
				.ForMember(des => des.SubjectName, opt => opt.MapFrom(src => src.Name));
		}
	}
}
