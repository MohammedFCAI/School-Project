namespace SchoolProject.Data.Entities
{
	public class Subject
	{
		public int SubjectId { get; set; }

		[StringLength(250)]
		public string Name { get; set; }

		// Relations..
		public List<StudentSubject> StudentSubjects { get; set; }
		public List<DepartmentSubject> DepartmentSubjects { get; set; }
	}
}
