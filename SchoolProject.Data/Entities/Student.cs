using System.Text.Json.Serialization;

namespace SchoolProject.Data.Entities
{
	public class Student
	{
		public int StudentId { get; set; }

		[StringLength(250)]
		public string Name { get; set; }

		[StringLength(500)]
		public string Address { get; set; }

		[StringLength(250)]
		public string Phone { get; set; }

		// Relations..
		public int DepartmentId { get; set; }

		[JsonIgnore]
		public Department Department { get; set; }

		[JsonIgnore]
		public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

	}
}
