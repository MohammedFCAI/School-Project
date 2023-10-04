using SchoolProject.Core.Features.Subjects.Commands.Models;

namespace SchoolProject.Core.Mappings.Subjects
{
	public partial class SubjectProfile
	{
		public void DeleteSubjectMapping()
		{
			CreateMap<DeleteSubjectCommand, Subject>()
				.ForMember(des => des.SubjectId, opt => opt.MapFrom(src => src.Id));
		}
	}
}
