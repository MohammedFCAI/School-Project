using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.Subjects.Commands.Responses;

namespace SchoolProject.Core.Mappings.Subjects
{
	public partial class SubjectProfile
	{
		public void AddSubjectMapping()
		{
			CreateMap<AddSubjectCommand, Subject>()
				.ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name));

			CreateMap<Subject, AddSubjectResponse>()
				.ForMember(des => des.Id, opt => opt.MapFrom(src => src.SubjectId));
		}
	}
}
