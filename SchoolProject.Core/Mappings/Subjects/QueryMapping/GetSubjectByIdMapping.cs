using SchoolProject.Core.Features.Subjects.Queries.Responses;

namespace SchoolProject.Core.Mappings.Subjects
{
	public partial class SubjectProfile
	{
		public void GetSubjectByIdMapping()
		{
			CreateMap<Subject, GetSubjectByIdResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.SubjectId));
		}
	}
}
