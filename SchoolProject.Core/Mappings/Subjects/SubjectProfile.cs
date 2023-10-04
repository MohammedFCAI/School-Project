namespace SchoolProject.Core.Mappings.Subjects
{
	public partial class SubjectProfile : Profile
	{
		public SubjectProfile()
		{
			GetSubjectListMapping();
			GetSubjectByIdMapping();
			AddSubjectMapping();
			UpdateSubjecttMapping();
			DeleteSubjectMapping();
		}
	}
}
