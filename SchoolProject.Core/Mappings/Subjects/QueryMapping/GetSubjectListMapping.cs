using SchoolProject.Core.Features.Subjects.Queries.Responses;

namespace SchoolProject.Core.Mappings.Subjects
{
	public partial class SubjectProfile
	{
		public void GetSubjectListMapping()
		{
			CreateMap<Subject, GetSubjectListResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.SubjectId));
		}
	}
}
