using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.Subjects.Commands.Responses;

namespace SchoolProject.Core.Mappings.Subjects
{
	public partial class SubjectProfile
	{
		public void UpdateSubjecttMapping()
		{
			CreateMap<UpdateSubjectCommand, Subject>()
				.ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(des => des.SubjectId, opt => opt.MapFrom(src => src.Id));

			CreateMap<Subject, UpdateSubjectResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.SubjectId));
		}
	}
}

