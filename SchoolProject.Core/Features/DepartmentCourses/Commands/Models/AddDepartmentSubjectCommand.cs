namespace SchoolProject.Core.Features.DepartmentCourses.Commands.Models
{
    public class AddDepartmentSubjectCommand : IRequest<Response<string>>
    {
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
    }
}
