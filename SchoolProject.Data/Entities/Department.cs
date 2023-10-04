namespace SchoolProject.Data.Entities
{
	public class Department
	{
		public int DepartmentId { get; set; }

		[StringLength(250)]
		public string Name { get; set; }

		// Relations..
		public List<Student> Students { get; set; }

		public List<DepartmentSubject> DepartmentSubjects { get; set; } = new List<DepartmentSubject>();

	}
}
